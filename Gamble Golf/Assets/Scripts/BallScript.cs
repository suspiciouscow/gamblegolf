using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {

    public bool canShoot = false;
    public float power = 5f;
    public Rigidbody rb;

    public Vector3 minPower;
    public Vector3 maxPower;

    public TrajectoryLine trajectoryLine;

    Camera camera;
    Vector3 force;
    Vector3 startPoint;
    Vector3 endPoint;
    int multiplier;

    void Start() {
        camera = Camera.main;
        trajectoryLine = GetComponent<TrajectoryLine>();
    }

    void Update() {
       
        multiplier = DiceNumberTextScript.diceNumber;

        if (canShoot) {
            // Get mouse position when press
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                startPoint = camera.ScreenToWorldPoint(mousePos);
                Debug.Log(startPoint);
            }

            // Render line FX during button hold
            if (Input.GetMouseButton(0)) {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                Vector3 currentPoint = camera.ScreenToWorldPoint(mousePos);
                trajectoryLine.RenderLine(startPoint, currentPoint);

            }
            
            Debug.Log(multiplier);
            // Turn off line FX and launch ball upon button release
            if (Input.GetMouseButtonUp(0)) {
                // Get Mouse Position when let go
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                endPoint = camera.ScreenToWorldPoint(mousePos);

                // Shoot ball
                force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x)
                                    , 0         
                                    , Mathf.Clamp(startPoint.z - endPoint.z, minPower.z, maxPower.z));
                rb.AddForce(multiplier* force * power, ForceMode.Impulse);

                // Turn off line FX
                trajectoryLine.EndLine();
                Score.score++;

            }
        }

        if (rb.velocity != new Vector3(0, 0, 0)) {
            canShoot = false;
        }
        else {
            canShoot = true;
        }

    }
}
