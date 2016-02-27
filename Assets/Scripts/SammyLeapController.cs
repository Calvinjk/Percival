using UnityEngine;
using System.Collections;
using Leap;

public class SammyLeapController : MonoBehaviour {

    public bool ________________________________;
    Leap.Controller controller;
    public GameObject cam;

    public float leapBoundaryX      = 250f;
    public float leapMinBoundaryY   = 100f;
    public float leapMaxBoundaryY   = 700f;
    public float leapBoundaryZ      = 150f;

    public float screenBoundaryX    = 15f;
    public float screenBoundaryY    = 6f;
    //public float screenMinZ         = 0f;
    //public float screenMaxZ         = 50f;

    // Use this for initialization
    void Start () {
        controller = new Leap.Controller();
        cam = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        Leap.Frame frame = controller.Frame();
        Leap.Hand hand = frame.Hands.Frontmost;
        Vector3 handPos = hand.PalmPosition.ToUnityScaled();


        /*
        //Boundary checks
        if (handPos.x > leapBoundaryX) { handPos = new Vector3(leapBoundaryX, handPos.y, handPos.z); }
        if (handPos.x < (-1 * leapBoundaryX)) { handPos = new Vector3((-1 * leapBoundaryX), handPos.y, handPos.z); }
        if (handPos.y > leapMaxBoundaryY) { handPos = new Vector3(handPos.x, leapMaxBoundaryY, handPos.z); }
        if (handPos.y < leapMinBoundaryY) { handPos = new Vector3(handPos.x, leapMinBoundaryY, handPos.z); }
       // if (handPos.z > leapBoundaryZ) { handPos = new Vector3(handPos.x, handPos.y, leapBoundaryZ); }
       // if (handPos.z < (leapBoundaryZ)) { handPos = new Vector3(handPos.x, handPos.y, (-1 * leapBoundaryZ)); }


        float xPercent = handPos.x / leapBoundaryX;
        float yPercent = 5f * (handPos.y - leapMinBoundaryY) / (leapMaxBoundaryY - leapMinBoundaryY);
        //float zPercent = handPos.z / leapBoundaryZ;

        float screenX = xPercent * screenBoundaryX;
        float screenY = (-1 * screenBoundaryY) + (yPercent * screenBoundaryY) + 2;
        float screenZ = cam.transform.position.z + 20f; //screenMinZ + (zPercent * screenMaxZ);

        transform.position = new Vector3(screenX, screenY, screenZ);

        Debug.Log(hand.GrabStrength);
        */
    }
}
