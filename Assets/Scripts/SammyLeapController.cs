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
        Leap.Finger finger = frame.Hands[0].Fingers[(int)Leap.Finger.FingerType.TYPE_INDEX];
        Vector3 fingerTipPos = finger.TipPosition.ToUnityScaled();

        //Boundary checks
        if (fingerTipPos.x > leapBoundaryX) { fingerTipPos = new Vector3(leapBoundaryX, fingerTipPos.y, fingerTipPos.z); }
        if (fingerTipPos.x < (-1 * leapBoundaryX)) { fingerTipPos = new Vector3((-1 * leapBoundaryX), fingerTipPos.y, fingerTipPos.z); }
        if (fingerTipPos.y > leapMaxBoundaryY) { fingerTipPos = new Vector3(fingerTipPos.x, leapMaxBoundaryY, fingerTipPos.z); }
        if (fingerTipPos.y < leapMinBoundaryY) { fingerTipPos = new Vector3(fingerTipPos.x, leapMinBoundaryY, fingerTipPos.z); }
       // if (fingerTipPos.z > leapBoundaryZ) { fingerTipPos = new Vector3(fingerTipPos.x, fingerTipPos.y, leapBoundaryZ); }
       // if (fingerTipPos.z < (leapBoundaryZ)) { fingerTipPos = new Vector3(fingerTipPos.x, fingerTipPos.y, (-1 * leapBoundaryZ)); }


        float xPercent = fingerTipPos.x / leapBoundaryX;
        float yPercent = 5f * (fingerTipPos.y - leapMinBoundaryY) / (leapMaxBoundaryY - leapMinBoundaryY);
        //float zPercent = fingerTipPos.z / leapBoundaryZ;

        float screenX = xPercent * screenBoundaryX;
        float screenY = (-1 * screenBoundaryY) + (yPercent * screenBoundaryY) + 2;
        float screenZ = cam.transform.position.z + 20f; //screenMinZ + (zPercent * screenMaxZ);

        transform.position = new Vector3(screenX, screenY, screenZ);

        Debug.Log(transform.position);

    }
}
