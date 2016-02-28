using UnityEngine;
using System.Collections;

public class SunflowerBossWeapon : MonoBehaviour {

    public GameObject missilePrefab;
    public float maxWeaponCooldown = 1f;
    public float minWeaponCooldown = 0.3f;
    public float attackSpeedGrowth = .99f;
    public float bulletSize = 1f;
    public float bulletSpeed = 100f;

    public bool ______________________________;

    public GameObject missileInstance;
    public float curWeaponCooldown = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (curWeaponCooldown <= 0) {
            curWeaponCooldown = maxWeaponCooldown;
            missileInstance = Instantiate(missilePrefab, new Vector3(Random.Range(0, 30), Random.Range(0, 30), transform.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
            missileInstance.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 2f), -1f) * bulletSpeed * Random.Range(1, 2));
        }
        else {
            curWeaponCooldown -= Time.deltaTime;
        }

        //Slowly increase fire rate to a cap
        maxWeaponCooldown *= attackSpeedGrowth;
        if (maxWeaponCooldown < minWeaponCooldown) { maxWeaponCooldown = minWeaponCooldown; }
    }
}
