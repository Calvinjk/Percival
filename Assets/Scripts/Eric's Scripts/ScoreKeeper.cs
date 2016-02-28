using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public long score = 0;
    public int scoreMultiplier = 272;
    Text playerText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        score += (long)(Time.deltaTime * scoreMultiplier);
        //playerText.text = "Score:" + score.ToString();
        //gameObject.text = "hello";
        GetComponent<Text>().text = "Score:" + score.ToString();
	}
}
