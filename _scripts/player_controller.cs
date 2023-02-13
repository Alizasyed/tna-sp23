using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float speed = 10.0f;

    public BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    //jump variables
    public float jumpSpeed = 10.0f;
    public float jumpTime ;
    public float buttonTime = 0.3f;
    bool jumping; 
    
    public Rigidbody2D rb;
    float jumpAmount = 15;



    private SpriteRenderer player_SR;
    private bool facing_right = true;

    // Start is called before the first frame update
    void Start()
    {
        player_SR = gameObject.GetComponent<SpriteRenderer>();
        rb.GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        //detec space key
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            jumping = true;
            jumpTime = 0;
        }

//if jumping true, add velicity to rb + increase jumptime
        if(jumping)
        { rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime){
            jumping = false;
        }



        // if (Input.GetKeyDown(moveLeft))
        if(Input.GetAxis("Horizontal")<0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            facing_right = false;
        }
        
        // if (Input.GetKeyDown(moveRight))
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            facing_right = true;


        }

        if(facing_right)
        {
            player_SR.flipX = false;
        }else
        {
            player_SR.flipX = true;
        }

    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f,Vector2.down, 0.1f, jumpableGround);
    }
}
