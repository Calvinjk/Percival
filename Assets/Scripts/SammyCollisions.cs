using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SammyCollisions : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
    {
        CalvinSpawner.state = CalvinSpawner.State.Tutorial;
        //Destroy(this.gameObject);
        SceneManager.LoadScene(1);
    }
}
