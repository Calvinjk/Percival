using UnityEngine;
using System.Collections;

public class CleanerBox : MonoBehaviour {

    public float zTrailDist = 0f;
    public bool _____________________________;
    public GameObject cam;


    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Main Camera");
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 camPos = cam.transform.position;
        transform.position = new Vector3(camPos.x, camPos.y, camPos.z - zTrailDist);

        if ((camPos.z - transform.position.z) < zTrailDist) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zTrailDist);
        }
	}


    //Clean up after yourself!
    void OnCollisionEnter(Collision coll) {
        Destroy(coll.gameObject);
    }
}
