using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
    public int scoreMultiplier = 2721;
    Text playerText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        score = (int)(Time.time * scoreMultiplier);
        //playerText.text = "Score:" + score.ToString();
        //gameObject.text = "hello";
        GetComponent<Text>().text = "Score:" + score.ToString();
	}
}
