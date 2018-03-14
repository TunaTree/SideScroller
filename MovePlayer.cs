using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode jump;

    public float horizVel = 0;  //moves player position horizontally on X - axis
    public float vertVel = 0;   //should move player about the Y-axis

    public int laneNum = 0;
    public string lockControl = "n";    //locks control while moving 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       GetComponent<Rigidbody>().velocity = new Vector3(horizVel, vertVel, 2);   

        if (Input.GetKeyDown(moveL) && (laneNum > -2) && (lockControl == "n"))        //if key is pressed "Left/A"
        {

            horizVel = -2;                  //set horizontal velocity to 

            laneNum -= 1;

            StartCoroutine(stopSlide());

            lockControl = "y";
            
        }
        if (Input.GetKeyDown(moveR) && (laneNum < 2)&&(lockControl == "n"))        //if key is pressed "Right/D"
        {

            horizVel = 2;                  //set horizontal velocity to 

            laneNum += 1;                   //

            StartCoroutine(stopSlide());

            lockControl = "y";

        }

        if (Input.GetKeyDown(jump)) // player jumps only if touching ground
        {
            vertVel += 2;

            StartCoroutine(stopJump());

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Portal") {

            SceneManager.LoadScene(1);

        }
    }
    IEnumerator stopJump() {

        yield return new WaitForSeconds(.3f);

        vertVel = 0;

    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);   //wait .5 seconds to move again

        horizVel = 0;

        lockControl = "n";

    }
}
