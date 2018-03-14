using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);    //start moving camera forward
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
