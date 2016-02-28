using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float camSpeed = 1f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + camSpeed);
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, camSpeed);
	}
}
