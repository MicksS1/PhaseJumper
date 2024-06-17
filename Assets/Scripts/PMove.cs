using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public Rigidbody2D player;
    public Animator moveAnim;
    public GameObject TP;
    private float move;
    [Range(0f, 20f)] public float speed = 10f;
    [Range(0f, 10f)] public float jumpStrength;
    public SpriteRenderer SR;
    public int jumpCount;
    [Range(0f, 10f)] public float dashForce;
    public float dashCD;
    public int dashCount;

    public bool isGround;
    public bool isObstacleR;
    public bool isObstacleL;
    private bool right;
    private bool left;
    private bool CD = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            SR.flipX = false;
            moveAnim.SetTrigger("goRun");
        }   

        else if (Input.GetKey(KeyCode.A))
        {
            SR.flipX = true;
            moveAnim.SetTrigger("goRun");
        }

        else
            moveAnim.SetTrigger("goIdle");

        // Jump

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            player.velocity = new Vector2(player.velocity.x, jumpStrength);
            jumpCount--;
        }

        if (Input.GetKeyDown(KeyCode.S))
            player.gravityScale = 5;
        
        else if (Input.GetKeyUp(KeyCode.S))
            player.gravityScale = 1;

        // TP

        //obstacleR = Physics2D.Raycast(Vector2.zero, Vector2.right);
        //obstacleL = Physics2D.Raycast(Vector2.zero, Vector2.left);

        right = SR.flipX.Equals(false);
        left = SR.flipX.Equals(true);

        if (Input.GetKeyDown(KeyCode.LeftShift) && right && dashCount > 0 && CD == false && isObstacleR == false)
        {
            Instantiate(TP, player.transform.position, player.transform.rotation); // Dash animation
            player.transform.Translate(dashForce, 0, 0);
            dashCount--;

            CD = true;
            Invoke("cooldown", dashCD);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && left && dashCount > 0 && CD == false && isObstacleL == false)
        {
            Instantiate(TP, player.transform.position, player.transform.rotation); // Dash animation
            player.transform.Translate(-dashForce, 0, 0);
            dashCount--;

            CD = true;
            Invoke("cooldown", dashCD);
        }
    }

    private void cooldown()
    {
        CD = false;
    }

    private void FixedUpdate()
    {
        // Move LR

        move = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(move * speed, player.velocity.y);
    }

    //private void OnTriggerStay2D(Collider2D coll)
    //{
    //    if (coll.gameObject.tag == "Ground")
    //    {
    //        isGround = true;
    //        //Debug.Log(isGround);
    //        jumpCount = 1; // --> 2 jump
    //        dashCount = 1;
    //    }
    //    else
    //    {
    //        isGround = false;
    //        //Debug.Log(isGround);
    //    }

    //}
}
