using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{

    private string objName;

    [SerializeField] Text ObjectText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeObjectName(string objname)
    {
        objName = objname;
        ObjectText.text = objname;
    }


}
