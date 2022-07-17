using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoleScript : MonoBehaviour
{
    
    public ParticleSystem particleSystem;
    public Button continueButton;

    void Start() {
        continueButton.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Ball") {
            collider.gameObject.SetActive(false);
            particleSystem.Play();
            continueButton.gameObject.SetActive(true);
        }
    }

}