using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gamestart : MonoBehaviour {


    public bool ________________________________;

    Leap.Controller controller;

    // Use this for initialization
    void Start ()
    {
        controller = new Leap.Controller();

    }
	
	// Update is called once per frame
	void Update () {
        Leap.Frame frame = controller.Frame();
        Leap.Hand hand = frame.Hands.Frontmost;

        float bluh = hand.GrabStrength;

        if (bluh == 1) {
            SceneManager.LoadScene(1);
        }

    }
    void OnCollisionEnter(Collision coll)
    {
        SceneManager.LoadScene(0);
        Destroy(coll.gameObject);
    }
}
