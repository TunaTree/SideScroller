using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayertrackCam : MonoBehaviour {

    private GameObject player;

    private Vector3 lastPosition;
    private float distanceToMove;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        lastPosition = player.transform.position;

        //GetComponent<Rigidbody>().velocity = new Vector2(2, 0);    // Vector2(x,y)start moving camera forward
    }
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Rigidbody>().velocity = new Vector2(2, 0);    // Vector2(x,y)start moving camera forward
        distanceToMove = player.transform.position.x - lastPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPosition = player.transform.position;

        
        //gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
