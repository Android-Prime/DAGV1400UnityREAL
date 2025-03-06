using UnityEngine;
using UnityEngine.UI; 

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDrainRate = 10f;
    public float staminaRegenRate = 5f;
    public Image staminaBarUI; 

    private bool isMoving;

    private void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    private void Update()
    {
        if (isMoving)
        {
            UseStamina(staminaDrainRate * Time.deltaTime);
        }
        else
        {
            RegenerateStamina(staminaRegenRate * Time.deltaTime);
        }
    }

    public void SetMoving(bool moving)
    {
        isMoving = moving;
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        UpdateStaminaUI();
        Debug.Log("Stamina Decreased: " + currentStamina);
    }

    private void RegenerateStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        UpdateStaminaUI();
        Debug.Log("Stamina Increased: " + currentStamina);
    }


    private void UpdateStaminaUI()
    {
        if (staminaBarUI != null)
        {
            staminaBarUI.fillAmount = currentStamina / maxStamina;
            Debug.Log("Stamina Bar Updated: " + staminaBarUI.fillAmount);
        }
        else
        {
            Debug.LogError("Stamina Bar UI not assigned! Assign it in the Inspector.");
        }
    }
}