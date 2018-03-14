using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;      //makes the platform
    public Transform generationPoint;   //where the platforms will be created
    public float distanceBetween;       //distance between platforms

    private float platformWidth;    //how big the platform is

    public int distanceBetweenMin;
    public int distanceBetweenMax;

    
   // public GameObject[] thePlatforms;
    private int platformSelector;


    private float[] platformWidths;
    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;

    private float heightChange;

	// Use this for initialization
	void Start () {

        platformWidths = new float[theObjectPools.Length];
        
        for(int i = 0; i < theObjectPools.Length; i++)
        {

            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<Collider2D>().transform.localScale.x;   //gest size of the collider<box,edge,polygon2D>
            //platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //gets the size of the platform
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);


            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);    //the current position of the platform

            if (heightChange > maxHeight)
            {

                heightChange = maxHeight;

            }
            else if (heightChange < minHeight)
            {

                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);

           GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();    //grabs the platform that is not active

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}
