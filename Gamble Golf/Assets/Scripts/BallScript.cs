using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {

    public static bool canShoot = false;
    public float power = 5f;
    public Rigidbody rigidBody;

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
            }

            // Render line FX during button hold
            if (Input.GetMouseButton(0)) {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                Vector3 currentPoint = camera.ScreenToWorldPoint(mousePos);
                trajectoryLine.RenderLine(startPoint, currentPoint);

            }
            
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
                rigidBody.AddForce(multiplier* force * power, ForceMode.Impulse);
                // Turn off line FX
                trajectoryLine.EndLine();
                Score.score++;
                canShoot = false;
            }
        }
        // Helps ball stop faster

        if (rigidBody.velocity != new Vector3(0, 0, 0)) {
            DiceScript.canRoll = true;
        }
        else { 
            DiceScript.canRoll = true;
        }
        if (Mathf.Abs(rigidBody.velocity.x) > 0.7f && Mathf.Abs(rigidBody.velocity.y) > 0.7f && Mathf.Abs(rigidBody.velocity.z) > 0.7f && !canShoot) {
                rigidBody.velocity = new Vector3(0, 0, 0);
        }
        
    }
}
