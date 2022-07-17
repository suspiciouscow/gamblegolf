using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    private GameObject ball;
    private Vector3 offset;

    void Start() {
        ball = GameObject.Find("Ball");
        offset = new Vector3 (0, transform.position.y, 0);
    }
    
    void LateUpdate() {
        Vector3 position = ball.transform.position;
        transform.position = position + offset;
    }
}
