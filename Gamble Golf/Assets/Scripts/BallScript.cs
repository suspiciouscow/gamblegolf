using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody rb;

    public Vector3 minPower;
    public Vector3 maxPower;

    Camera camera;
    Vector3 force;
    Vector3 startPoint;
    Vector3 endPoint;


    void Start() {
        camera = Camera.main;
    }


    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // Get Mouse Position when press
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            startPoint = camera.ScreenToWorldPoint(mousePos);
            Debug.Log(startPoint);
        }
        if (Input.GetMouseButtonUp(0)) {
            // Get Mouse Position when let go
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            endPoint = camera.ScreenToWorldPoint(mousePos);

            // Shoot ball
            force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x)
                                , 0         
                                , Mathf.Clamp(startPoint.z - endPoint.z, minPower.z, maxPower.z));
            rb.AddForce(force * power, ForceMode.Impulse);
        }

    }
}
