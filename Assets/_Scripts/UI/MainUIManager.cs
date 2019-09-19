using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{

    private string objName;

    [SerializeField] Text ObjectText;
    

    public void ChangeObjectName(string objname)
    {
       // Debug.Log("Triggered"+objname);
        objName = objname;
        ObjectText.text = objname;
    }


}
