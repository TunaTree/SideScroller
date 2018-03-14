using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour {

    public float boostSpeed = 20.0f;
    public bool onGround;
    
    public float moveSpeed;

    Rigidbody2D rb;
    [Range(1, 10)]
    public float jumpVelocity;

    

    // Use this for initialization
    void Start() {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);


        if ((Input.GetButtonDown("Jump"))) {

            Jump();
         
        }
        

    }
    void Jump() {
        if (onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
           
            onGround = false;
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {        //collision detects the ground 

            onGround = true;                    //sets onGround back to true 

        }
        if (col.gameObject.tag == "Ramp")
        {

            Debug.Log("BoostSpeed");
            rb.AddForce(Vector2.right * boostSpeed, ForceMode2D.Force);
        }
        else if (col.gameObject.tag == "Portal")
        {

            GameOver();
        }
    }

    void GameOver() {
        Debug.Log("GameOver");
            
    }
}
