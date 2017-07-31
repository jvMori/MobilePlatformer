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
    public bool isGrounded;
    public Transform feet;
    public float feetRadius;
    public float boxWidth;
    public float boxHeight;
    public LayerMask whatIsGround;
    public float doubleJumpDelay;
    public bool canDoubleJump;
    public Transform leftBulletSpawnPos, rightBulletSpawnPos;
    public GameObject leftBullet, rightBullet;
    public bool sfxOn;
    public bool canFire;

    private Rigidbody2D rbd;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isJumping, leftPressed, rightPressed;

       
	void Start () {

        rbd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {

       // isGrounded = Physics2D.OverlapCircle(feet.position, feetRadius, whatIsGround);
        isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight), 360.0f, whatIsGround);

        float playerSpeed = Input.GetAxis("Horizontal");
        playerSpeed *= speedBoost;

        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();


        if (Input.GetButtonDown("Jump"))
            Jump();

        if (Input.GetButtonDown("Fire1"))
            FireBullet();

        if (leftPressed)
            MoveHorizontal(-speedBoost);
        if (rightPressed)
            MoveHorizontal(speedBoost);

        ShowFalling();
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(feet.position, feetRadius);
        Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));
    }

    void MoveHorizontal(float playerSpeed)
    {
        rbd.velocity = new Vector2(playerSpeed, rbd.velocity.y);
        if (playerSpeed > 0)
            sr.flipX = false;
        else if (playerSpeed < 0)
            sr.flipX = true;

        if (!isJumping)
            anim.SetInteger("State", 1);
    }

    void StopMoving()
    {
        rbd.velocity = new Vector2(0, rbd.velocity.y);

        if (!isJumping)
            anim.SetInteger("State", 0);
    }

    void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            rbd.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", 2);

            Invoke("EnableDoubleJump", doubleJumpDelay);
        }

        if (!isGrounded && canDoubleJump)
        {
            rbd.velocity = Vector2.zero;
            rbd.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", 2);
            canDoubleJump = false;
        }

    }
    public void MobileMoveLeft()
    {
        leftPressed = true;
    }

    public void MobileMoveRight()
    {
        rightPressed = true;
    }

    public void MobileMoveStop()
    {
        leftPressed = false;
        rightPressed = false;

        StopMoving();
    }

    public void MobileFireBullets()
    {
        FireBullet();
    }

    public void MobileJump()
    {
        Jump();
    }


    void FireBullet()
    {
        if (canFire)
        {
            if (sr.flipX)
                Instantiate(leftBullet, leftBulletSpawnPos.position, Quaternion.identity);
            else
                Instantiate(rightBullet, rightBulletSpawnPos.position, Quaternion.identity);
        }
    }

    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    void ShowFalling()
    {
        if (rbd.velocity.y < 0)
            anim.SetInteger("State", 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
            isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coin":
                if (sfxOn)
                    SfxController.instance.ShowCoinSparkle(collision.gameObject.transform.position);
                break;

            case "Water":
                SfxController.instance.ShowSplashEffect(collision.gameObject.transform.position);
                GameCtrl.instance.PlayerDrowned(collision.gameObject);
                break;

            case "Powerup_Bullet":
                canFire = true;
                Vector3 powerUpPos = collision.gameObject.transform.position;
                Destroy(collision.gameObject);

                if (sfxOn)
                    SfxController.instance.ShowBulletSparkle(powerUpPos);
                break;

            default:
                break;
        }
    }
}
