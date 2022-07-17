using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingArea : MonoBehaviour
{
    public Vector3 SpawnPoint;
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Ball"))
        {
            other.gameObject.transform.position = SpawnPoint;
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
