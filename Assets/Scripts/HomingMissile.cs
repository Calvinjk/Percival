using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour {

    public float damping = 1f;
    public float missilePower = 10f;

    public bool ___________________________;

    public GameObject player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Sammy the Smog Cloud");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * missilePower);

        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
