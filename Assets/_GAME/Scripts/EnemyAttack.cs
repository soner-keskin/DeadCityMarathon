using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // Saldýrý hasarý
    public float attackRange = 1.0f; // Saldýrý menzili
    public float attackCooldown = 1.0f; // Saldýrý aralýðý

    private Animator animator;
    private Transform player; // Oyuncunun pozisyonunu tutmak için
    private PlayerHealth playerHealth; // Oyuncunun saðlýk bileþeni
   

    private bool canAttack = true; // Saldýrýyý yapma izni

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        playerHealth = player.GetComponent<PlayerHealth>(); // Oyuncunun saðlýk bileþenini al
    }

    void Update()
    {
        // Karakter ölü deðilse
        if (!playerHealth.IsDead())
        {
            // Oyuncu düþmanýn saldýrý menzili içerisinde mi kontrol et
            if (Vector2.Distance(transform.position, player.position) <= attackRange && canAttack)
            {
                // Saldýrý animasyonunu oynat
                animator.SetTrigger("attack");
                // Oyuncuya hasar ver
                playerHealth.TakeDamage(damageAmount);
                // Saldýrý aralýðýna göre saldýrýyý tekrar etme süresini belirle
                canAttack = false;
                Invoke("ResetAttack", attackCooldown);
            }
        }
        else
        {
            // Karakter öldüðünde, saldýrý animasyonunu durdur
            animator.ResetTrigger("attack");
        }

        if(playerHealth.IsDead())
        {

            animator.SetTrigger("Idle");
            
            
        }
    }

    // Saldýrý aralýðýndaki sürenin sonunda saldýrýyý tekrar etmek için kullanýlan fonksiyon
    void ResetAttack()
    {
        canAttack = true;
    }
}
