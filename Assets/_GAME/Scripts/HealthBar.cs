using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerHealth playerHealth; // PlayerHealth s�n�f�na eri�im sa�lamak i�in referans
    [SerializeField] private Image healthBarFill; // Sa�l�k �ubu�unu dolduracak olan Image referans�
    [SerializeField] private Gradient healthGradient; // Sa�l�k �ubu�unun rengini belirlemek i�in gradient referans�

    void Start()
    {
        // E�er playerHealth referans� atanmam��sa, sahnedeki Player objesinden PlayerHealth bile�enini bul
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        // Health bar'�n doldurma k�sm�n�n referans� atanmam��sa, bu obje alt�ndaki Image bile�enini bul
        if (healthBarFill == null)
        {
            healthBarFill = GetComponentInChildren<Image>();
        }

        // Sa�l�k �ubu�unun ba�lang�� rengini ayarla
        UpdateHealthBar();
    }

    void Update()
    {
        // Her g�ncellemede sa�l�k �ubu�unu g�ncelle
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Oyuncunun maksimum ve mevcut sa�l�k de�erlerine g�re sa�l�k �ubu�unun doluluk oran�n� hesapla
        float fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        // Sa�l�k �ubu�unun doluluk oran�n� g�ncelle
        healthBarFill.fillAmount = fillAmount;

        // Doluluk oran�na g�re renk gradyan�ndan uygun rengi se�
        healthBarFill.color = healthGradient.Evaluate(fillAmount);
    }
}
