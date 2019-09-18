using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneManager : MonoBehaviour
{
    [Header("Message Times")]
    [SerializeField] GameTime[] MessageTimes;
    [Space(20)]
    [Header("Images")]
    [SerializeField] GameObject PhoneUI;
    
    [SerializeField] Texture2D[] MessageImages;
    [Space(20)]
    [Header("Others")]
    [SerializeField] GameObject PlayerPrefab;


    private TextMeshProUGUI NotificationText;
    [SerializeField] private Image notification;
    private TextMeshProUGUI InstructionText;

    private RawImage PhoneImage;

    private AnxietyCounter counter;

    private int maxMessage;
    private int currentMessage;
    
    private FMOD.Studio.EventInstance _messageGet;
    private FMOD.Studio.EventInstance _messageSend;

    private bool _messageSent = false;
    
    
    void Start()
    {
        PhoneImage = PhoneUI.transform.GetChild(0).GetComponent<RawImage>();

        NotificationText = PhoneUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>() ;

        InstructionText = PhoneUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        counter = FindObjectOfType<AnxietyCounter>();
        PhoneImage.enabled = false;
        NotificationText.enabled = false;
        notification.enabled = false;
        InstructionText.enabled = false;
        
        _messageGet = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Message_Get");
        _messageSend = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Message_Send");
        
    }

    // Update is called once per frame
    public void CheckTimes()
    {
        
        for (int i = 0; i < MessageTimes.Length; i++)
        {
            GameTime g = MessageTimes[i];
            
            //when the current time is equal to something from the array, enable notifications
            if (counter.GetTime().hour==g.hour && counter.GetTime().minutes == g.minutes)
            {
                //set the next max message
                maxMessage = i;
                currentMessage = i;

                if (PhoneImage.enabled == false)
                {
                    NotificationText.enabled = true;
                    notification.enabled = true;
                }

                _messageGet.start();
                
                PhoneImage.GetComponent<RawImage>().texture = MessageImages[i];
            }
            
        }
    }

    private void Update()
    {
        //just a flag for input not to trigger twice
        bool keyPressed = false;

        //close phone
        if (PhoneImage.enabled)
        {
            InstructionText.enabled = true;

            //close phone
            if (Input.GetKeyDown(KeyCode.E) && keyPressed==false)
            {
                //enable movement with closed phone
                PlayerPrefab.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 2;
                PlayerPrefab.GetComponent<PlayerMovement>().enabled = true;
                
                keyPressed = true;
                InstructionText.enabled = false;
                PhoneImage.enabled = false;
            }

            //go to previous message
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentMessage--;
            }

            //go to next message
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentMessage++;
            }

            //clamp the messages
            if (currentMessage < 0)
                currentMessage = 0;
            if (currentMessage > maxMessage)
                currentMessage = maxMessage;

            //set the phone image
            PhoneImage.GetComponent<RawImage>().texture = MessageImages[currentMessage];
        }

        //open phone
        if (Input.GetKeyDown(KeyCode.E) && keyPressed==false)
        {
            //disable movement with open phone
            PlayerPrefab.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 0; 
            PlayerPrefab.GetComponent<PlayerMovement>().enabled = false;

            PhoneImage.enabled = true;

            if (_messageSent == false)
            {
                _messageSend.start();
            }

            NotificationText.enabled = false;
            notification.enabled = false;
            InstructionText.enabled = true;
        }
    }
}
