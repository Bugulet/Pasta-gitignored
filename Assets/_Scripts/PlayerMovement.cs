using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{

    [FormerlySerializedAs("Player")] 
    [SerializeField] private GameObject player;

    public float speed;

    private float _moveHor;
    private float _moveVer;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        if (player == null)
        {
            Debug.Log("PLAYER NOT ASSIGNED FOR MOVEMENT");
        }
    }

    // Update is called once per frame
    private void Update()
    {
            _moveHor = Input.GetAxis ("Horizontal")*speed;
            _moveVer = Input.GetAxis ("Vertical")*speed;
            _moveHor *= Time.deltaTime;
            _moveVer *= Time.deltaTime;

            transform.Translate(_moveHor, 0.0f, _moveVer);
    }

    public bool MovementGetter()
    {
        if (_moveHor != 0 || _moveVer != 0)
        {
            return true;
        }
        else return false;
    }
}
