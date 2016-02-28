using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Leap;

public class GameEnd : MonoBehaviour
{
      
    public bool ________________________________;

    Leap.Controller controller;

    // Use this for initialization
    void Start()
    {
        controller = new Leap.Controller();

    }

    // Update is called once per frame
    void Update()
    {
        Leap.Frame frame = controller.Frame();
        Leap.Hand hand = frame.Hands.Frontmost;
        Vector normalizedHandPos = Leap.Vector.Zero;

        if (frame.InteractionBox.IsValid)
        {
            normalizedHandPos = frame.InteractionBox.NormalizePoint(hand.PalmPosition, true);
        }
        Vector3 handPos = normalizedHandPos.ToUnityScaled();
        //means they were all the way left
        if (handPos.x == 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
