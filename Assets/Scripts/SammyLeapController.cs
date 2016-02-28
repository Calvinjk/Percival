using UnityEngine;
using System.Collections;
using Leap;

public class SammyLeapController : MonoBehaviour {

    public bool ________________________________;
    Leap.Controller controller;
    public GameObject cam;
    public bool fastPhysics = false;

    public float minX = -13f;
    public float maxX = 12f;
    public float minY = -4f;
    public float maxY = 10;
    public float zPos = 20f;

    // Use this for initialization
    void Start () {
        controller = new Leap.Controller();
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update() {
        Vector3 camPos = cam.transform.position;

        Leap.Frame frame = controller.Frame();
        Leap.Hand hand = frame.Hands.Frontmost;
        Vector normalizedHandPos = Leap.Vector.Zero;

        if (frame.InteractionBox.IsValid) {
            normalizedHandPos = frame.InteractionBox.NormalizePoint(hand.PalmPosition, true);
        }

        Vector3 handPos = normalizedHandPos.ToUnityScaled();

        float xPos = minX + ((maxX - minX) * handPos.x);
        float yPos = minY + ((maxY - minY) * handPos.y);

        transform.position = new Vector3(camPos.x + xPos, camPos.y + yPos, camPos.z + zPos);


        //Slow motion controller
        if (hand.GrabStrength == 1f) {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime /= 10;
            fastPhysics = true;
        } else {
            Time.timeScale = 1.0f;
            if (fastPhysics == true) {
                Time.fixedDeltaTime *= 10;
                fastPhysics = false;
            }
        }
    }
}
