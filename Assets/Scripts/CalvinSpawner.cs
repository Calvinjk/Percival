using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CalvinSpawner : MonoBehaviour {

    public enum State {Tutorial, Trees, Env, TreePeopleHiRain, Boss0, TreePeopleLowRain, AddClouds, AddLollipops, AddSun, Faster, Boss1, End, Endless};
    public static State state;

    public GameObject floorPrefab;
    public GameObject[] enemyPrefabs;
    public GameObject[] boss;
    public float floorDistance      = 3f;
    public float drawDistance       = 100f;
    public float floorOffset        = 10f;
    public float enemySpawnTimer    = 1f;

    public bool ________TIMES________;
    public float tutorialTime = 0f;
    public float treesTime = 10f;
    public float envTime = 15f;
    public float treePeopleHiRainTime = 8f;
    public float boss0Time = 10f;
    public float treePeopleLowRainTime = 15f;
    public float addCloudsTime = 10f;
    public float addLollipopsTime = 10f;
    public float addSunTime = 10f;
    public float fasterTime = 15f;
    public float boss1Time = 10f;

    public bool ________________;
    public Vector3 pos;
    public float lastPlacedPos;
    public Vector3 placedCamPos;
    public float curSpawnTimer      = 0f;
    public bool randomAngle         = true;
    public CameraMovement camMvt;
    public static bool inBossBattle = false;
    public float stateTimer = 0f;

    // Use this for initialization
    void Start () {
        state = State.Tutorial;
        stateTimer = tutorialTime;
        camMvt = (CameraMovement) GameObject.Find("Main Camera").GetComponent(typeof(CameraMovement));

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
        //Endless mode Toggle
        if (Input.GetKeyDown(KeyCode.E)) {
            if (state == State.Endless) {
                state = State.Tutorial;
                GameObject.Find("ENDLESS_TEXT").GetComponent<Text>().enabled = false;
            } else {
                state = State.Endless;
                GameObject.Find("ENDLESS_TEXT").GetComponent<Text>().enabled = true;
                enemySpawnTimer = .5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { 
            state = State.Boss0;
            stateTimer = boss0Time;
            camMvt.camSpeed = 45;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { 
            state = State.Boss1;
            stateTimer = boss1Time;
            camMvt.camSpeed = 75;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Title");
        }


        //Dynamically create path if needed
        pos = transform.position;
        if ((lastPlacedPos - pos.z) < drawDistance) {
            Instantiate(floorPrefab, new Vector3(pos.x, pos.y - floorDistance, lastPlacedPos + floorOffset), Quaternion.identity);
            lastPlacedPos += floorOffset;
        }

        //START THE STATE MACHINE

        //State machine variables
        int enemyNum = 0;
        int bossNum = -1;
        bool lowRain = false;
        stateTimer -= Time.deltaTime;

        switch (state) {
            case State.Tutorial:
                //Stuff to do in this state
                inBossBattle = false;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Trees;
                    stateTimer = treesTime;
                    camMvt.camSpeed = 30;
                }
                break;
            case State.Trees:
                //Stuff to do in this state
                enemyNum = 0;
                enemySpawnTimer = 1f;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Env;
                    stateTimer = envTime;
                    camMvt.camSpeed = 35;
                }
                break;
            case State.Env:
                //Stuff to do in this state
                enemyNum = 1;
                enemySpawnTimer = .5f;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.TreePeopleHiRain;
                    stateTimer = treePeopleHiRainTime;
                    camMvt.camSpeed = 40;
                }
                break;
            case State.TreePeopleHiRain:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 3);
                enemySpawnTimer = .5f;
                lowRain = false;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Boss0;
                    stateTimer = boss0Time;
                    camMvt.camSpeed = 45;
                }
                break;
            case State.Boss0:
                //Stuff to do in this state
                enemyNum = -1;
                bossNum = 0;

                //Getting ready to switch states
                if (stateTimer < 0 && !inBossBattle) {
                    state = State.TreePeopleLowRain;
                    stateTimer = treePeopleLowRainTime;
                    camMvt.camSpeed = 50;
                    bossNum = -1;
                }
                break;
            case State.TreePeopleLowRain:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 3);
                enemySpawnTimer = 0.5f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.AddClouds;
                    stateTimer = addCloudsTime;
                    camMvt.camSpeed = 55;
                }
                break;
            case State.AddClouds:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 4);
                enemySpawnTimer = .4f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.AddLollipops;
                    stateTimer = addLollipopsTime;
                    camMvt.camSpeed = 60;
                }
                break;
            case State.AddLollipops:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 5);
                enemySpawnTimer = .4f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.AddSun;
                    stateTimer = addSunTime;
                    camMvt.camSpeed = 65;
                }
                break;
            case State.AddSun:
                //Stuff to do in this state  
                enemyNum = Random.Range(0, 6);
                enemySpawnTimer = .4f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Faster;
                    stateTimer = fasterTime;
                    camMvt.camSpeed = 70;
                }
                break;
            case State.Faster:
                //Stuff to do in this state  
                enemyNum = Random.Range(0, 6);
                enemySpawnTimer = .35f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Boss1;
                    stateTimer = boss1Time;
                    camMvt.camSpeed = 75;
                }
                break;
            case State.Boss1:
                //Stuff to do in this state
                enemyNum = -1;
                bossNum = 1;

                //Getting ready to switch states
                if (stateTimer < 0 && !inBossBattle) {
                    state = State.End;
                    bossNum = -1;
                }
                break;
            case State.End:
                //Stuff to do in this state
                enemyNum = -1;

                //ENDSCREEN
                SceneManager.LoadScene("End");  
                break;
            case State.Endless:
                enemyNum = Random.Range(0, 6);
                enemySpawnTimer *= .999f;

                if (Random.Range(0, 2) == 0) { lowRain = true; }
                else { lowRain = false; }

                break;
        }

        //Start randomly creating enemies based on values from the current state
        if (curSpawnTimer > enemySpawnTimer && enemyNum != -1) {
            curSpawnTimer = 0f;

            float enemyX = Random.Range(-11, 11);

            float enemyY = -1f;
            if (enemyPrefabs[enemyNum].name == "Tree_Object") {
                enemyY = (pos.y - floorDistance);
            } else if (enemyPrefabs[enemyNum].name == "Env_Object") {
                enemyY = (pos.y - floorDistance) + 1.5f;
            } else if (enemyPrefabs[enemyNum].name == "Rainbow_Object") {
                randomAngle = false;
                if (lowRain) {
                    enemyY = (pos.y - floorDistance) + Random.Range(8f, 14f);
                } else {
                    enemyY = (pos.y - floorDistance) + Random.Range(30f, 50f);
                }
            } else if (enemyPrefabs[enemyNum].name == "Lolli_Object") {
                enemyY = (pos.y - floorDistance) + 2f;
            } else if (enemyPrefabs[enemyNum].name == "Sun_Object") {
                enemyY = (pos.y - floorDistance) + Random.Range(8f, 18f);
            } else if (enemyPrefabs[enemyNum].name == "Cloud_Object") {
                enemyY = (pos.y - floorDistance) + Random.Range(8f, 18f);
                randomAngle = false;
            }

            float enemyZ = pos.z + drawDistance - floorOffset;

            Vector3 enemySpawnPoint = new Vector3(enemyX, enemyY, enemyZ);

            Quaternion enemySpawnRot;
            if (randomAngle) {
                enemySpawnRot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            } else {
                if (enemyPrefabs[enemyNum].name == "Cloud_Object") {
                    enemySpawnRot = Quaternion.identity;
                } else {
                    enemySpawnRot = Quaternion.Euler(0f, 90f, 0f);
                }
            }

            Instantiate(enemyPrefabs[enemyNum], enemySpawnPoint, enemySpawnRot);
        } else {
            curSpawnTimer += Time.deltaTime;
        }

        if (bossNum != -1) {
            switch (bossNum) {
                case 0:
                    if (!inBossBattle) {
                        Instantiate(boss[0], new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), Quaternion.Euler(0f, 250f, 0f));
                        inBossBattle = true;
                    }
                    break;
                case 1:
                    if (!inBossBattle) {
                        Instantiate(boss[1], new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), Quaternion.Euler(0f, 180f, 0f));
                        inBossBattle = true;
                    }
                        break;
            }
        }

	}
}
