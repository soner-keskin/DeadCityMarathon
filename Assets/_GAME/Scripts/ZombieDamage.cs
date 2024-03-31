using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth _playerHealth;
    Animator animator;
    


    private void Start()
    {
        animator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>();

        
    }

    private void Update()
    {

        
    }
    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Player")
        {


            animator.SetTrigger("attack");
            _playerHealth.TakeDamage(damage);
            



        }
    }

    
    
}
