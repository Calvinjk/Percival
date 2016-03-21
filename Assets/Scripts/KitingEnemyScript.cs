using UnityEngine;
using System.Collections;

public class KitingEnemyScript : MonoBehaviour {

    public float initialSpawnDist   = 400f;
    public float moveSpeed      = 1f;
    public float killDistance       = 10f;

    public bool _____________________________;

    public GameObject   cam;
    public GameObject   player;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera");
        Vector3 camPos = cam.transform.position;
        transform.position = new Vector3(camPos.x, camPos.y + 4f, camPos.z + initialSpawnDist);

        player = GameObject.Find("Sammy the Smog Cloud");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float camSpeed = cam.GetComponent<Rigidbody>().velocity.z;
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, transform.position.z + moveSpeed);
        if (Mathf.Abs(transform.position.z - player.transform.position.z) < killDistance) {
            CalvinSpawner.inBossBattle = false;
            Destroy(gameObject);
        }
    }
}
