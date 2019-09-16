using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private GameObject Player;

    [SerializeField] private float Speed;

    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Debug.Log("PLAYER NOT ASSIGNED FOR MOVEMENT");
        }
        else
        {
            if (Player.GetComponent<Rigidbody>() == null)
            {
                Debug.Log("RIGIDBODY FOR MOVEMENT DOESNT EXIST");
            }
            else
            {
                playerRigidbody = Player.GetComponent<Rigidbody>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponentInChildren<Camera>().enabled)
        {
            float speedMultiplier = Speed * Time.deltaTime;
            
            if (Input.GetKey(KeyCode.W))
            {
                playerRigidbody.AddForce(speedMultiplier * Player.transform.forward);
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerRigidbody.AddForce(-speedMultiplier * Player.transform.right);
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerRigidbody.AddForce(speedMultiplier * Player.transform.right);
            }

            if (Input.GetKey(KeyCode.S))
            {
                playerRigidbody.AddForce(-speedMultiplier * Player.transform.forward);
            }
        }
    }
}
