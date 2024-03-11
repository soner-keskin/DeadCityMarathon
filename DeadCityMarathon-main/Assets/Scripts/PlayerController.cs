using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float horizontalInput;
    bool isFacingRight = true;
    float jumpPower = 3.0f;
    bool isJumping = false;


    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");


        FlipSprite();

        if(Input.GetButtonDown("Jump") && !isJumping) {
        
            rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
            isJumping = true;
        
        
        }
        
 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {

        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {

            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
