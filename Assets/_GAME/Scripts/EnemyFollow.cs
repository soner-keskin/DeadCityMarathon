using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    private void FixedUpdate()
    

    {
        
       transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        animator.SetFloat("xVelo", Math.Abs(rb.velocity.x));




    }

    
}

