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

    public float moveSpeed = 1f;  //Not applicable to Leap Motion or Mouse control schemes

    public bool ________________________________;

    float xPos = 0;
    float yPos = 0;

    Leap.Controller controller;
    Globals globals;
    public GameObject cam;

    public bool sloMo = false;
    public bool sloRe = false;
    public float curSloMo;



    // Use this for initialization
    void Start () {
        globals = (Globals)GameObject.Find("Globals").GetComponent(typeof(Globals));
        cam = GameObject.Find("Main Camera");
        curSloMo = maxSloMo;

        if (globals.controlScheme == Globals.ControlScheme.LeapMotion) {
            controller = new Leap.Controller();
        }
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

        switch (globals.controlScheme){
            case Globals.ControlScheme.LeapMotion:
                Leap.Frame frame = controller.Frame();
                Leap.Hand hand = frame.Hands.Frontmost;
                Vector normalizedHandPos = Leap.Vector.Zero;

                if (frame.InteractionBox.IsValid) {
                    normalizedHandPos = frame.InteractionBox.NormalizePoint(hand.PalmPosition, true);
                }

                Vector3 handPos = normalizedHandPos.ToUnityScaled();

                xPos = minX + ((maxX - minX) * handPos.x);
                yPos = minY + ((maxY - minY) * handPos.y);

                if (hand.GrabStrength == 1f && (curSloMo > minActiveSlow || sloMo)) { SetSlowMotion(true); }
                else                                                                { SetSlowMotion(false); }

                break;
            case Globals.ControlScheme.Keyboard:
                if (Input.GetKey(KeyCode.A))           { xPos -= moveSpeed; }
                if (Input.GetKey(KeyCode.D))           { xPos += moveSpeed; }
                if (Input.GetKey(KeyCode.W))           { yPos += moveSpeed; }
                if (Input.GetKey(KeyCode.S))           { yPos -= moveSpeed; }
                if (Input.GetKey(KeyCode.LeftArrow))   { xPos -= moveSpeed; }
                if (Input.GetKey(KeyCode.RightArrow))  { xPos += moveSpeed; }
                if (Input.GetKey(KeyCode.UpArrow))     { yPos += moveSpeed; }
                if (Input.GetKey(KeyCode.DownArrow))   { yPos -= moveSpeed; }

                //Boundary checks
                if (xPos > maxX) { xPos = maxX; }
                if (xPos < minX) { xPos = minX; }
                if (yPos > maxY) { yPos = maxY; }
                if (yPos < minY) { yPos = minY; }

                if (Input.GetKey(KeyCode.Space) && (curSloMo > minActiveSlow || sloMo)) { SetSlowMotion(true); }
                else                                                                    { SetSlowMotion(false); }

                break;
        }
        
        transform.position = new Vector3(camPos.x + xPos, camPos.y + yPos, camPos.z + zPos);


        //Slow motion controller
        /*
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
        */
    }

    void SetSlowMotion(bool onOff) {
        if (onOff) {
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