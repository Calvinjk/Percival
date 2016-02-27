using UnityEngine;
using System.Collections;

public class EnvMotionScript : MonoBehaviour {

    void Start() {
        
    }

    void Update() {

    }

	public void Attack() {
        GetComponent<Animator>().SetBool("Attacking", true);
    }
}
