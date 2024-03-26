using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController _playerController;

    public int maxHealth;
    public int health;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {

          _playerController.Die();

            
            
        }

    }
}
