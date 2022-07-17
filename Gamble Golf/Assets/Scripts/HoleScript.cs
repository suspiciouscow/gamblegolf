using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleScript : MonoBehaviour
{
    
    public ParticleSystem particleSystem;
    public string nextLevel;

    void Start() {
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Ball") {
            collider.gameObject.SetActive(false);
            particleSystem.Play();
            SceneManager.LoadScene(nextLevel);
        }
    }

}