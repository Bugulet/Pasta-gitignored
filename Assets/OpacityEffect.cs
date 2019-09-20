using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityEffect : MonoBehaviour
{

    private Renderer self;

    private Material[] materials;

    private AnxietyManager manager;

    private int anxietyMemory = 0;

    void Start()
    {
        manager = FindObjectOfType<AnxietyManager>();
        anxietyMemory = manager.GetAnxiety();
        self = GetComponent<Renderer>();
        materials = self.materials;
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < materials.Length; i++)
        {
            Color c = new Color();
            c = self.materials[i].GetColor("_Color");
            if (manager.GetAnxiety() > 20)
                c.a = manager.GetAnxiety() / 70f;
            else c.a = 0;
            self.materials[i].SetColor("_Color", c);
        }
        
    }

}
