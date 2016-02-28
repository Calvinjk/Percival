using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public GameObject floorPrefab;
    public GameObject[] enemyPrefabs;
    public float floorDistance      = 3f;
    public float drawDistance       = 100f;
    public float floorOffset        = 10f;
    public float enemySpawnTimer    = 1f;
    public bool ________________;
    public float vacuumStart        = 12f;
    public float highRainbowStart   = 4f;
    public float boss1Start         = 36f;
    public float lowRainbowStart =  53f;
    public float cloudStart =  60f;
    public float lollipopStart =  70f;
    public float boss2Start = 100f;
    public float sunStart =  130f;
    public float boss3Start = 200f; 
    public bool ______________________________;
    public Vector3 pos;
    public float lastPlacedPos;
    public Vector3 placedCamPos;
    public float curSpawnTimer      = 0f;
    public bool randomAngle         = true;
    public CameraMovement cam;
    public GameObject boss1;
    public GameObject boss2;
    public static bool inBossBattle = false;

    // Use this for initialization
    void Start () {
        //Times:
        vacuumStart += Time.time;
        highRainbowStart += Time.time;
        boss1Start += Time.time;
        lowRainbowStart += Time.time;
        cloudStart += Time.time;
        boss2Start += Time.time;
        sunStart += Time.time;
        boss3Start += Time.time;

        cam = (CameraMovement)GameObject.Find("Main Camera").GetComponent(typeof(CameraMovement));



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

        //limit the enemyPrefabs Range
        int enemyNum = 0;

        if (Time.time < vacuumStart) {

        } else if (Time.time < highRainbowStart) {
            cam.camSpeed = 28f;
            enemySpawnTimer = 1.5f;
            print(Time.time);//start vacuums
            enemyNum = Random.Range(0, 2);
        }
        else if (Time.time < boss1Start)
        { //start rainbows
            enemySpawnTimer -= .00001f;
            enemyNum = Random.Range(0, 3);
        }
        else if (!inBossBattle && Time.time < lowRainbowStart)
        {
            enemySpawnTimer = 99999999f;
            if (!inBossBattle)
            {
                inBossBattle = true;
                //first bit of boss logic here, like stop spawning other stuff or something
                Instantiate(boss1, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z),
                    Quaternion.Euler(0, 270, 0));
            }

        }
        else if (!inBossBattle && Time.time < cloudStart)
        {
            //TESTING FOR NOW
            enemyNum = Random.Range(0, 5);
            cam.camSpeed = 30f;
            enemySpawnTimer = 1.3f;
        }
        else if (!inBossBattle && Time.time < lollipopStart)
        {
            enemyNum = Random.Range(0, 6);

            cam.camSpeed = 32f;
            enemySpawnTimer = 1f;
        }
        else if (!inBossBattle && Time.time < boss2Start)
        {
            enemyNum = Random.Range(0, 7);

            cam.camSpeed = 35f;
            enemySpawnTimer = .8f;
        }
        else if (!inBossBattle && Time.time < sunStart)
        {
            enemySpawnTimer = 999999999;
            //boss2 logic here
        }
        else if (!inBossBattle && Time.time < boss3Start)
        {

            cam.camSpeed = 40f;
            enemySpawnTimer = .5f;
            enemyNum = Random.Range(0, 7);
        }
        else {

            //boss 3 logic here
            enemyNum = Random.Range(0, 7);
            enemySpawnTimer -= .00001f;


        }

        //increase speed
        


        /*
         
    public float boss2Start = 100f;
    public float sunStart =  130f;
    public float boss3Start = 200f; 
        */

        //Start randomly creating enemies
        if (curSpawnTimer > enemySpawnTimer) {
            curSpawnTimer = 0f;

           
            float enemyX = Random.Range(-10, 10);

            float enemyY = -1f;
            if (enemyPrefabs[enemyNum].name == "Tree_Object") {
                enemyY = (pos.y - floorDistance) + 1.5f;
            } else if (enemyPrefabs[enemyNum].name == "Env_Object") {
                enemyY = (pos.y - floorDistance) + 1.5f;
            } else if (enemyPrefabs[enemyNum].name == "Rainbow_Object") {
                //make the rainbows really high
                if (Time.time < boss1Start)
                {
                    Debug.Log("High Rainbow time: " + Time.time);
                    enemyY = (pos.y - floorDistance) + Random.Range(30f, 50f);
                }
                else {
                    enemyY = (pos.y - floorDistance) + Random.Range(8f, 14f);
                }
                randomAngle = false;
            } else if (enemyPrefabs[enemyNum].name == "Lolli_Object") {
                enemyY = (pos.y - floorDistance) + 2f;
            } else if (enemyPrefabs[enemyNum].name == "Sun_Object")
            {
                enemyY = (pos.y - floorDistance) + Random.Range(8f, 18f);
            } else if (enemyPrefabs[enemyNum].name == "Cloud_Object")
            {
                enemyY = (pos.y - floorDistance) + Random.Range(8f, 18f);
                randomAngle = false;
            }
            float enemyZ = pos.z + drawDistance - floorOffset;
            Vector3 enemySpawnPoint = new Vector3(enemyX, enemyY, enemyZ);
            if (randomAngle == true) {
                Instantiate(enemyPrefabs[enemyNum], enemySpawnPoint, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
            }
            else
            {
                if (enemyPrefabs[enemyNum].name == "Cloud_Object")
                {
                    Instantiate(enemyPrefabs[enemyNum], enemySpawnPoint, Quaternion.Euler(0f, 0f, 0f));
                }
                else
                {
                    Instantiate(enemyPrefabs[enemyNum], enemySpawnPoint, Quaternion.Euler(0f, 90f, 0f));
                }
            }

        } else {
            curSpawnTimer += Time.deltaTime;
        }
	}

}
