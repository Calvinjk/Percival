using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour {

    public bool __________________________;
    public Globals globals;

	// Use this for initialization
	void Start () {
        globals = (Globals) GameObject.Find("Globals").GetComponent(typeof(Globals));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //0 for Leap Motion
    //1 for Mouse
    //2 for Keyboard
    public void SetControlScheme(int schemeNum) {
        switch(schemeNum) {
            case 0:
                globals.controlScheme = Globals.ControlScheme.LeapMotion;
                break;
            case 1:
                globals.controlScheme = Globals.ControlScheme.Mouse;
                break;
            case 2:
                globals.controlScheme = Globals.ControlScheme.Keyboard;
                break;
            default:
                Debug.LogError("Incorrect control scheme selected");
                break;
        }

        //Done setting the control scheme variable, move onto the title screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //This line of code will load the NEXT scene in the buildIndex
    }
}
