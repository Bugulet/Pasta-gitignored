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
    [SerializeField] private GameObject memoUI;
    
    [SerializeField] Texture2D[] MessageImages;
    
    [Space(20)]
    [Header("Others")]
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] private GameObject dupePlayer;
    
    private GameObject NotificationText;
    [SerializeField] private Image notification;

    [SerializeField] private GameObject switchingInstructions;
    
    private TextMeshProUGUI InstructionText;

    private RawImage PhoneImage;

    private RawImage _memoImage;

    private AnxietyCounter counter;

    private int maxMessage;
    private int currentMessage;
    
    private FMOD.Studio.EventInstance _messageGet;
    private FMOD.Studio.EventInstance _messageSend;

    private bool _messageSent = false;

    [HideInInspector] public bool phoneOpen = false;
    
    
    void Start()
    {
        PhoneImage = PhoneUI.transform.GetChild(0).GetComponent<RawImage>();
        _memoImage = memoUI.transform.GetChild(0).GetComponent<RawImage>();
        
        memoUI.SetActive(false);
        
        NotificationText = PhoneUI.transform.GetChild(1).gameObject;

        InstructionText = PhoneUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        counter = FindObjectOfType<AnxietyCounter>();
        PhoneImage.enabled = false;
        _memoImage.enabled = false;
        
        NotificationText.SetActive(false);
        InstructionText.enabled = false;
        switchingInstructions.SetActive(false);
        
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
                    NotificationText.SetActive(true);
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
            phoneOpen = true;
            _memoImage.enabled = false;
            switchingInstructions.SetActive(true);
            
            InstructionText.enabled = true;

            //close phone
            if (Input.GetKeyDown(KeyCode.E) && keyPressed == false)
            {
                phoneOpen = false;
                //enable movement with closed phone
                PlayerPrefab.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 2;
                PlayerPrefab.GetComponent<PlayerMovement>().enabled = true;
                dupePlayer.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 2;

                keyPressed = true;
                InstructionText.enabled = false;
                PhoneImage.enabled = false;
                // memoUI.SetActive(false);
                switchingInstructions.SetActive(false);
            }

            //go to previous message
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentMessage--;
            }

            //go to next message
            if (Input.GetKeyDown(KeyCode.S))
            {
                currentMessage++;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                PhoneImage.enabled = false;
                _memoImage.enabled = true;
            }

            //clamp the messages
            if (currentMessage < 0)
                currentMessage = 0;
            if (currentMessage > maxMessage)
                currentMessage = maxMessage;

            //set the phone image
            PhoneImage.GetComponent<RawImage>().texture = MessageImages[currentMessage];
        }

        if (_memoImage.enabled)
        {
            memoUI.SetActive(true);
            PhoneImage.enabled = false;
            
            if (Input.GetKeyDown(KeyCode.E) && keyPressed==false)
            {
                //enable movement with closed phone
                PlayerPrefab.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 2;
                PlayerPrefab.GetComponent<PlayerMovement>().enabled = true;
                dupePlayer.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 2;
                
                keyPressed = true;
                InstructionText.enabled = false;
                _memoImage.enabled = false;
                memoUI.SetActive(false);
                switchingInstructions.SetActive(false);
                phoneOpen = true;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _memoImage.enabled = false;
                PhoneImage.enabled = true;
                memoUI.SetActive(false);
            }
        } 
        
        //open phone
        if (Input.GetKeyDown(KeyCode.E) && keyPressed==false)
        {
            //disable movement with open phone
            PlayerPrefab.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 0; 
            PlayerPrefab.GetComponent<PlayerMovement>().enabled = false;
            dupePlayer.transform.GetChild(0).GetComponent<LookatMouse>().sensitivity = 0;

            PhoneImage.enabled = true;

            if (_messageSent == false)
            {
                _messageSend.start();
            }

            NotificationText.SetActive(false);
            InstructionText.enabled = true;
        }
    }
}