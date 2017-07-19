using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    /// <summary>
    /// make the player move left/right
    /// </summary>
    /// 

    [Tooltip("This is a positive float that speeds up player movement")]
    public float speedBoost; // initialize 5
    public float jumpSpeed; // initialize 600

    private Rigidbody2D rbd;
    private SpriteRenderer sr;
       
	void Start () {

        rbd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {

        float playerSpeed = Input.GetAxis("Horizontal");
        playerSpeed *= speedBoost;

        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();

             
        if (Input.GetButtonDown("Jump"))
            Jump();
        
    }

    void MoveHorizontal(float playerSpeed)
    {
        rbd.velocity = new Vector2(playerSpeed, rbd.velocity.y);
        if (playerSpeed > 0)
            sr.flipX = false;
        else if (playerSpeed < 0)
            sr.flipX = true;
    }

    void StopMoving()
    {
        rbd.velocity = new Vector2(0, rbd.velocity.y);
    }

    void Jump()
    {
        rbd.AddForce(new Vector2(0, jumpSpeed));
    }

   
}
