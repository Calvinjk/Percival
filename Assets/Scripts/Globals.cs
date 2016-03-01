using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

    public enum ControlScheme { LeapMotion, Mouse, Keyboard };
    public ControlScheme controlScheme;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);  //This allows this object to live on through scene changes
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
