using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SammyCollisions : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.name);
        Destroy(this.gameObject);
        SceneManager.LoadScene(1);
    }
}
