using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public GameObject floorPrefab;
    public GameObject[] enemyPrefabs;
    public float floorDistance      = 3f;
    public float drawDistance       = 100f;
    public float floorOffset        = 10f;
    public float enemySpawnTimer    = 1f;
    public bool ______________________________;
    public Vector3 pos;
    public float lastPlacedPos;
    public Vector3 placedCamPos;
    public float curSpawnTimer      = 0f;
    public bool randomAngle         = true;

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

        //Start randomly creating enemies
        if (curSpawnTimer > enemySpawnTimer) {
            curSpawnTimer = 0f;

            int enemyNum = Random.Range(0, enemyPrefabs.Length);
            float enemyX = Random.Range(-10, 10);

            float enemyY = -1f;
            if (enemyPrefabs[enemyNum].name == "Dumb_Tree") {
                enemyY = (pos.y - floorDistance);
            } else if (enemyPrefabs[enemyNum].name == "Env_Object") {
                enemyY = (pos.y - floorDistance) + 1.5f;
            } else if (enemyPrefabs[enemyNum].name == "Rainbow_Object") {
                enemyY = (pos.y - floorDistance) + Random.Range(6f, 14f);
                randomAngle = false;
            } else if (enemyPrefabs[enemyNum].name == "Lolli_Object") {
                enemyY = (pos.y - floorDistance) + 2f;
            } else if (enemyPrefabs[enemyNum].name == "Sun_Object")
            {
                enemyY = (pos.y - floorDistance) + Random.Range(8f, 18f);
            }
            float enemyZ = pos.z + drawDistance - floorOffset;
            Vector3 enemySpawnPoint = new Vector3(enemyX, enemyY, enemyZ);
            if (randomAngle == true) {
                Instantiate(enemyPrefabs[enemyNum], enemySpawnPoint, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
            }
            else
            {
                Instantiate(enemyPrefabs[enemyNum], enemySpawnPoint, Quaternion.Euler(0f, 90f, 0f));
            }

        } else {
            curSpawnTimer += Time.deltaTime;
        }
	}

    //Clean up after yourself!
    void OnCollisionEnter(Collision coll) {
        Destroy(coll.gameObject);
    }
}
