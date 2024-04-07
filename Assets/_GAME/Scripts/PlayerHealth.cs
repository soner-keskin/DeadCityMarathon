using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerAttack _playerAttack;
    
    

    public int maxHealth = 200;
    public int currentHealth;
    private Animator animator;
    private bool isDead = false;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerController = GetComponent<PlayerController>(); 
        
        
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage; // Hasar� mevcut sa�l�ktan ��kar

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                Die();

                

            }
        }
    }


    void Die()
    {
        isDead = true;

        animator.SetTrigger("die");

        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;


    }

    // Karakterin �l�p �lmedi�ini kontrol eden metod
    public bool IsDead()
    {
        return isDead;
    }

   
}
