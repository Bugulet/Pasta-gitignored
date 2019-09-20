using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{

    private AnxietyManager manager;
    private ParticleSystem self;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AnxietyManager>();
        self = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        self.emissionRate = Mathf.Clamp( (manager.GetAnxiety()-40)/4,0,30);
        self.maxParticles = Mathf.Clamp((manager.GetAnxiety()) / 4, 0, 100);
    }
}
