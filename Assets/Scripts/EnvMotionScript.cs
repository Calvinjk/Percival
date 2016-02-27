﻿using UnityEngine;
using System.Collections;

public class EnvMotionScript : MonoBehaviour {

    public float    attackDistance = 10f;
    public bool     __________________________________;
    GameObject sammy;

    void Start() {
        sammy = GameObject.Find("Sammy the Smog Cloud");
    }

    void Update() {
        if (DistanceToObject(sammy) < attackDistance) {
            //Attack();
        }
    }

	void Attack() {
        GetComponent<Animator>().SetBool("Attacking", true);
    }

    float DistanceToObject(GameObject obj) {
        Debug.Log(transform.position.z - obj.transform.position.z);
        return (transform.position.z - obj.transform.position.z);
    }
}
