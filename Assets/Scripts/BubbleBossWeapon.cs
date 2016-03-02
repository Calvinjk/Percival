using UnityEngine;
using System.Collections;

public class BubbleBossWeapon : MonoBehaviour {

    public GameObject   littleMePrefab;
    public float        maxWeaponCooldown   = 1f;
    public float        bulletSize          = .20f;
    public float        bulletSpeed         = 100f;

    public bool ______________________________;

    public GameObject littleMeInstance;
    public float curWeaponCooldown = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (curWeaponCooldown <= 0) {
            curWeaponCooldown = maxWeaponCooldown;
            littleMeInstance = Shoot();
            float vecX = Random.Range(-2f, 2f);
            float vecY = Random.Range(-1f, 2f);
            littleMeInstance.GetComponent<Rigidbody>().AddForce(new Vector3(vecX, vecY, -1f) * bulletSpeed * Random.Range(1f,2f));
        } else {
            curWeaponCooldown -= Time.deltaTime;
        }
	}

    GameObject Shoot() {
        return Instantiate(littleMePrefab, transform.position, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject;
    }
}
