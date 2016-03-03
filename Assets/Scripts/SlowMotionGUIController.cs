using UnityEngine;
using System.Collections;

public class SlowMotionGUIController : MonoBehaviour {

    float maxBarSize = 3f;

    public bool ____________________________;

    public float maxSloMo;
    public float curSloMo;

    public bool sloMo;
    public bool sloRe;

    public GameObject leftParticle;
    public GameObject rightParticle;

    SammyLeapController samLeapController;
    
	// Use this for initialization
	void Start () {
        samLeapController = (SammyLeapController) GameObject.Find("Sammy the Smog Cloud").GetComponent(typeof(SammyLeapController));
        leftParticle = GameObject.Find("LeftParticleSystem");
        rightParticle = GameObject.Find("RightParticleSystem");
        maxBarSize = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        maxSloMo = samLeapController.maxSloMo;
        curSloMo = samLeapController.curSloMo;

        sloMo = samLeapController.sloMo;
        sloRe = samLeapController.sloRe;  

        if (sloMo ^ sloRe) {
            GetComponent<MeshRenderer>().enabled = true;
            leftParticle.SetActive(true);
            rightParticle.SetActive(true);

            float percentageLeft = curSloMo / maxSloMo;
            transform.localScale = new Vector3(maxBarSize * percentageLeft, transform.localScale.y, transform.localScale.z);
        } else {
            GetComponent<MeshRenderer>().enabled = false;
            leftParticle.SetActive(false);
            rightParticle.SetActive(false);
        }
	}
}
