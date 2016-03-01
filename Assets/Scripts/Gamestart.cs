using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamestart : MonoBehaviour {


    public bool ________________________________;
    public Globals globals;
    public Text startText;
    Leap.Controller controller;

    // Use this for initialization
    void Start () {
        globals = (Globals)GameObject.Find("Globals").GetComponent(typeof(Globals));
        startText = GameObject.Find("HowToStart").GetComponent<Text>();

        //Only do leapMotion stuff if leapMotion is the controlScheme.  Hopefully will fix crashing problem
        if (globals.controlScheme == Globals.ControlScheme.LeapMotion) {
            controller = new Leap.Controller();
        }
    }
	
	// Update is called once per frame
	void Update () {
        switch (globals.controlScheme) {
            case Globals.ControlScheme.LeapMotion:
                Leap.Frame frame = controller.Frame();

                startText.text = "Make a fist to start!";

                if (frame.Hands.Frontmost.GrabStrength == 1) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                break;
            case Globals.ControlScheme.Mouse:
                startText.text = "Click to start!";
                if (Input.GetKeyUp(KeyCode.Mouse0)) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }   
                break;
            case Globals.ControlScheme.Keyboard:
                startText.text = "Press Enter to start!";
                if (Input.GetKeyUp(KeyCode.Return)) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                break;
            default:
                Debug.LogError("Incorrect control scheme selected");
                break;
        }
    }
}
