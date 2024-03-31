using UnityEngine;

public class Slower : MonoBehaviour
{
    // Yava�latma katsay�s�
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Karakter zemine temas etti�inde kontrol edelim
        if (collision.CompareTag("Player"))
        {
            // Karakterin h�z�n� yava�lat
            PlayerController player = collision.GetComponent<PlayerController>();
            player.moveSpeed = 0.5f;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Karakterin h�z�n� yava�lat
            PlayerController player = collision.GetComponent<PlayerController>();
            player.moveSpeed = 2.0f;
        }
    }


}