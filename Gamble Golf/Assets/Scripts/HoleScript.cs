using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Ball") {
            Destroy(collider.gameObject);
        }
    }
}