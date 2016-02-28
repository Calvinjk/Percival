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
        Vector3 campos = cam.transform.position;
        transform.position = new Vector3(campos.x, campos.y, campos.z - zTrailDist);
	
	}


    //Clean up after yourself!
    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);
    }
}
