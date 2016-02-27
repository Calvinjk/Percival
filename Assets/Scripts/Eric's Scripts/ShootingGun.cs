using UnityEngine;
using System.Collections;

public class ShootingGun : MonoBehaviour {
    public float        timeMultiplier      = 1f;
    public float        forceMultiplier     = 1f;
    public float        bulletScale = 1f;
    public GameObject   bulletPrefab;
    public bool ________________________;
    public GameObject   bulletInstance;
    public float        timeInterval        = 0f;
    public 

	// Use this for initialization
	void Start () {
        timeInterval += Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        timeInterval += Time.deltaTime;

        if (timeInterval >= 1)
        {
            // Create bullet position vector
            Vector3 bulletVector = new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.localScale.z);

            // Create bullet
            bulletInstance = Instantiate(bulletPrefab, bulletVector, Quaternion.identity) as GameObject;
            
            /// Update bullet scale
            bulletInstance.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);

            // Create bullet rigidbody
            Rigidbody bulletRigid = bulletInstance.GetComponent<Rigidbody>();

            // Add force to bullet
            bulletRigid.AddForce(0f, 0f, forceMultiplier);

            // Reset time interval
            timeInterval = 0;
        }
	}
}
