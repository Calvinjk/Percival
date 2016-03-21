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
    public float floorPos           = -3f;
    public float drawDistance       = 100f;
    public float floorOffset        = 10f;
    public float floorSpan          = 15f;
    public float enemySpawnTimer    = .01f;

    public bool ________TIMES________;
    public float tutorialTime = 0f;
    public float treesTime = 10f;
    public float envTime = 15f;
    public float treePeopleHiRainTime = 8f;
    public float boss0Time = 1f;
    public float treePeopleLowRainTime = 15f;
    public float addCloudsTime = 10f;
    public float addLollipopsTime = 10f;
    public float addSunTime = 10f;
    public float fasterTime = 15f;
    public float boss1Time = 1f;

    public bool ________________;
    public Vector3 pos;
    public float lastPlacedPos;
    public Vector3 placedCamPos;
    public float curSpawnTimer      = 0f;
    public bool randomAngle         = true;
    public static bool inBossBattle = false;
    public float stateTimer = 0f;

    // Use this for initialization
    void Start () {
        state = State.Tutorial;
        stateTimer = tutorialTime;

        pos = transform.position;
        lastPlacedPos = -floorOffset * 2;

        //Create the inital ground blocks
        while (lastPlacedPos < drawDistance) {
            float zPlacement = pos.z + lastPlacedPos + floorOffset;

            //Make a line of floor tiles along the X axis at this Z position
            for (float i = -(floorOffset * floorSpan); i < (floorOffset * floorSpan); i += floorOffset) {
                Instantiate(floorPrefab, new Vector3(pos.x + i, floorPos, zPlacement), Quaternion.identity);
            }

            lastPlacedPos = zPlacement;
            placedCamPos = pos;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { 
            state = State.Boss1;
            stateTimer = boss1Time;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Title");
        }


        //Dynamically create path if needed
        pos = transform.position;
        if ((lastPlacedPos - pos.z) < drawDistance) {
            for (float i = -(floorOffset * floorSpan); i < (floorOffset * floorSpan); i += floorOffset) {
                Instantiate(floorPrefab, new Vector3(pos.x + i, floorPos, lastPlacedPos + floorOffset), Quaternion.identity);
            }
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
                }
                break;
            case State.Trees:
                //Stuff to do in this state
                enemyNum = 0;
                enemySpawnTimer = 0.01f;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Env;
                    stateTimer = envTime;
                }
                break;
            case State.Env:
                //Stuff to do in this state
                enemyNum = 1;
                enemySpawnTimer = .01f;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.TreePeopleHiRain;
                    stateTimer = treePeopleHiRainTime;
                }
                break;
            case State.TreePeopleHiRain:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 3);
                enemySpawnTimer = .01f;
                lowRain = false;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Boss0;
                    stateTimer = boss0Time;
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
                    bossNum = -1;
                }
                break;
            case State.TreePeopleLowRain:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 3);
                enemySpawnTimer = 0.01f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.AddClouds;
                    stateTimer = addCloudsTime;
                }
                break;
            case State.AddClouds:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 4);
                enemySpawnTimer = .01f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.AddLollipops;
                    stateTimer = addLollipopsTime;
                }
                break;
            case State.AddLollipops:
                //Stuff to do in this state
                enemyNum = Random.Range(0, 5);
                enemySpawnTimer = .01f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.AddSun;
                    stateTimer = addSunTime;
                }
                break;
            case State.AddSun:
                //Stuff to do in this state  
                enemyNum = Random.Range(0, 6);
                enemySpawnTimer = .01f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Faster;
                    stateTimer = fasterTime;
                }
                break;
            case State.Faster:
                //Stuff to do in this state  
                enemyNum = Random.Range(0, 6);
                enemySpawnTimer = .01f;
                lowRain = true;

                //Getting ready to switch states
                if (stateTimer < 0) {
                    state = State.Boss1;
                    stateTimer = boss1Time;
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

            float enemyX = Random.Range(transform.position.x - (floorSpan * floorOffset), transform.position.x + (floorSpan * floorOffset));

            float enemyY = -1f;
            if (enemyPrefabs[enemyNum].name == "Tree_Object") {
                enemyY = (floorPos);
            } else if (enemyPrefabs[enemyNum].name == "Env_Object") {
                enemyY = (floorPos) + 1.5f;
            } else if (enemyPrefabs[enemyNum].name == "Rainbow_Object") {
                randomAngle = false;
                if (lowRain) {
                    enemyY = (floorPos) + Random.Range(8f, 14f);
                } else {
                    enemyY = (floorPos) + Random.Range(30f, 50f);
                }
            } else if (enemyPrefabs[enemyNum].name == "Lolli_Object") {
                enemyY = (floorPos) + 2f;
            } else if (enemyPrefabs[enemyNum].name == "Sun_Object") {
                enemyY = (floorPos) + Random.Range(8f, 18f);
            } else if (enemyPrefabs[enemyNum].name == "Cloud_Object") {
                enemyY = (floorPos) + Random.Range(8f, 18f);
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
