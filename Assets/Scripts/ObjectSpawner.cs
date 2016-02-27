using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public GameObject floorPrefab;
    public GameObject[] enemyPrefabs;
    public float floorDistance      = 3f;
    public float drawDistance       = 100f;
    public float floorOffset        = 10f;
    public bool ______________________________;
    public Vector3 pos;
    public float lastPlacedPos;
    public Vector3 placedCamPos;

	// Use this for initialization
	void Start () {
        pos = transform.position;

        lastPlacedPos = -floorOffset;

        //Create the inital ground blocks
        while (lastPlacedPos < drawDistance) {
            float zPlacement = pos.z + lastPlacedPos + floorOffset;
            Instantiate(floorPrefab, new Vector3(pos.x, pos.y - floorDistance, zPlacement), Quaternion.identity);

            lastPlacedPos = zPlacement;
            placedCamPos = pos;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Dynamically create path if needed
        pos = transform.position;
        if ((lastPlacedPos - pos.z) < drawDistance) {
            Instantiate(floorPrefab, new Vector3(pos.x, pos.y - floorDistance, lastPlacedPos + floorOffset), Quaternion.identity);
            lastPlacedPos += floorOffset;
        }



	}

    //Clean up after yourself!
    void OnCollisionEnter(Collision coll) {
        Destroy(coll.gameObject);
    }
}
