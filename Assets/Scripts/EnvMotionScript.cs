using UnityEngine;
using System.Collections;

public class EnvMotionScript : MonoBehaviour {

    public float    attackDistance = 10f;
    
    public float camRatio = 1f;
    public bool     __________________________________;
    GameObject sammy;
    public CameraMovement cam;

    void Start() {
        sammy = GameObject.Find("Sammy the Smog Cloud");
        GetComponent<Animator>().SetBool("Idle", true);

        cam = (CameraMovement)GameObject.Find("Main Camera").GetComponent(typeof(CameraMovement));
    }

    void Update() {
        GetComponent<Animator>().SetBool("Idle", false);
        if (DistanceToObject(sammy) < attackDistance * camRatio) {
            Attack();
        }
    }

	void Attack() {
        GetComponent<Animator>().SetBool("Attacking", true);
    }

    float DistanceToObject(GameObject obj) {
        return (transform.position.z - obj.transform.position.z);
    }
}
