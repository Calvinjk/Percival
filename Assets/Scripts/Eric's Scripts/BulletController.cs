using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float timeInterval = 0f;

	// Use this for initialization
	void Start () {
        timeInterval += Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        timeInterval += Time.deltaTime;
	}

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.name != "Plane")
        {
            Destroy(obj.gameObject);
        }

        Destroy(gameObject);
    }

    void OnCollisionStay(Collision obj)
    {

    }

    void OnCollisionExit(Collision obj)
    {

    }
}
