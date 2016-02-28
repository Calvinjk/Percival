using UnityEngine;
using System.Collections;
using Leap;

public class SammyLeapController : MonoBehaviour {

    public float maxSloMo = 100f;
    public float sloMoDrain = 1f;
    public float minActiveSlow = 20f;
    public float sloRecharge = 1f;

    public float minX = -13f;
    public float maxX = 12f;
    public float minY = -4f;
    public float maxY = 10;
    public float zPos = 20f;

    public bool ________________________________;

    Leap.Controller controller;
    public GameObject cam;

    public bool sloMo = false;
    public bool sloRe = false;
    public float curSloMo;



    // Use this for initialization
    void Start () {
        controller = new Leap.Controller();
        cam = GameObject.Find("Main Camera");
        curSloMo = maxSloMo;
    }

    // Update is called once per frame
    void Update() {
        if (sloMo) {
            sloRe = false;
            curSloMo -= sloMoDrain;
            if (curSloMo <= 0) {
                sloMo = false;
            }
        } else {
            if (curSloMo < maxSloMo) {
                curSloMo += sloRecharge;
                sloRe = true;
            } else {
                sloRe = false;
                curSloMo = maxSloMo;
            }
        }

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
        if (hand.GrabStrength == 1f && (curSloMo > minActiveSlow || sloMo)) {
            Time.timeScale = 0.2f;
            if (sloMo == false) {
                Time.fixedDeltaTime /= 10;
                sloMo = true;
            }
        } else {
            Time.timeScale = 1.0f;
            if (sloMo == true) {
                Time.fixedDeltaTime *= 10;
                sloMo = false;
            }
        }
    }
}
