using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerController playerController; // PlayerHealth s�n�f�na eri�im sa�lamak i�in referans
    [SerializeField] private Image staminaBarFill; // Sa�l�k �ubu�unu dolduracak olan Image referans�
    [SerializeField] private Gradient staminaGradient; // Sa�l�k �ubu�unun rengini belirlemek i�in gradient referans�

    void Start()
    {
        // E�er playerHealth referans� atanmam��sa, sahnedeki Player objesinden PlayerHealth bile�enini bul
        if (playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        // Health bar'�n doldurma k�sm�n�n referans� atanmam��sa, bu obje alt�ndaki Image bile�enini bul
        if (staminaBarFill == null)
        {
            staminaBarFill = GetComponentInChildren<Image>();
        }

        // Sa�l�k �ubu�unun ba�lang�� rengini ayarla
        UpdateStaminaBar();
    }

    void Update()
    {
        // Her g�ncellemede sa�l�k �ubu�unu g�ncelle
        UpdateStaminaBar();
    }

    void UpdateStaminaBar()
    {
        // Oyuncunun maksimum ve mevcut sa�l�k de�erlerine g�re sa�l�k �ubu�unun doluluk oran�n� hesapla
        float fillAmount = (float)playerController.energy / playerController.maxEnergy;
        // Sa�l�k �ubu�unun doluluk oran�n� g�ncelle
        staminaBarFill.fillAmount = fillAmount;

        // Doluluk oran�na g�re renk gradyan�ndan uygun rengi se�
        staminaBarFill.color = staminaGradient.Evaluate(fillAmount);
    }
}
