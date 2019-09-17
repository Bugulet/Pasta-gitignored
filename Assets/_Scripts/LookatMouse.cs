
using UnityEngine;

public class LookatMouse : MonoBehaviour
{
    private Vector2 mouseLook;
    private Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public GameObject Player;

    private void Start()
    {
        //Player = this.transform.parent.gameObject;
    }
    void Update()
    {
        if (GetComponent<Camera>().enabled)
        {

            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

            Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);

            
        }
    }
}
