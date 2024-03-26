using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {

            playerHealth.TakeDamage(damage);
            ZombieAttack();



        }
    }

    private void ZombieAttack()
    {
        animator.SetTrigger("attack");
        
    }
}
