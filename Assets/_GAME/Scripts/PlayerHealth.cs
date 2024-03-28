using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;
    

    public int maxHealth;
    public int currentHealth;
    private Animator animator;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
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
                Die(); // E�er sa�l�k s�f�ra d��erse, karakteri �ld�r
            }
        }
    }

    public void Die()
    {
        isDead = true;

        animator.SetTrigger("die");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;

        
    }

    // Karakterin �l�p �lmedi�ini kontrol eden metod
    public bool IsDead()
    {
        return isDead;
    }
}
