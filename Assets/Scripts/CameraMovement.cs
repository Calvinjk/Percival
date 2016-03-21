using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float zFollowDist = 20f;
    public float yHoverDist = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 sammyPos = GameObject.Find("Sammy the Smog Cloud").transform.position;
        //TODO - Change the following line to Lerping?
        transform.position = new Vector3(sammyPos.x, yHoverDist, sammyPos.z - zFollowDist);
	}
}
