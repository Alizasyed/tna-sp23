using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behavior : MonoBehaviour

{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            rb2.velocity = new Vector2(moveSpeed, 0f);
            //move right
        }
        else
        {
            rb2.velocity = new Vector2(-moveSpeed, 0f);

            //move left
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2.velocity.x)), transform.localScale.y);
    }
}
