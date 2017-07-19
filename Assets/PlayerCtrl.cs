using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    /// <summary>
    /// make the player move left/right
    /// </summary>
    /// 

    [Tooltip("This is a positive float that speeds up player movement")]
    public float speedBoost;
    private Rigidbody2D rbd;
       
	void Start () {

        rbd = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        float playerSpeed = Input.GetAxis("Horizontal");
        playerSpeed *= speedBoost;

        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();
    }

    void MoveHorizontal(float playerSpeed)
    {
        rbd.velocity = new Vector2(playerSpeed, rbd.velocity.y);
    }

    void StopMoving()
    {
        rbd.velocity = new Vector2(0, rbd.velocity.y);
    }
}
