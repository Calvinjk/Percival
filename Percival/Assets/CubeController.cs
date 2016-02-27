using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
    public float    speedMultiplier     = 1f;
    public float    forceMultiplier     = 1f;
    public bool     ________________________________;
    public float    horizontalInput     = 0f;
    public float    verticalInput       = 0f;

    public float    jumpValue           = 0f;
    public int      jumpCount           = 0;
    public bool     grounded            = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rigidbody.AddForce(new Vector3(0,1,0) * forceMultiplier);
            jumpCount++;
        }
        
        Vector3 vel = new Vector3(horizontalInput * speedMultiplier, rigidbody.velocity.y, verticalInput * speedMultiplier);
        rigidbody.velocity = vel;
        
        //rigidbody.AddForce(V3) 

        /*
         * V3 is a Vector3 which tells direction of force and |V3| is how strong the force is
         *I recommend using Vector3.normalized which returns a new vector in the same direction as V3, but with a magnitude of EXACTLY 1
         *Reason this is nice is you can us a new variable, jumpPower to 100% control how hard the guy jumps.   (V3.normalized * jumpPower)
         *
         */
        
    }

    void OnCollisionEnter(Collision obj) 
    {
        //grounded = true;
        jumpCount = 0;

    }

    void OnCollisionStay(Collision obj)
    {

    }

    void OnCollisionExit(Collision obj)
    {
        //grounded = false;
    }
}
