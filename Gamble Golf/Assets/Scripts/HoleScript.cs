using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    
    public ParticleSystem particleSystem;

    void Start() {
    }




    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Ball") {
            collider.gameObject.SetActive(false);
            particleSystem.Play();
        }
    }
}