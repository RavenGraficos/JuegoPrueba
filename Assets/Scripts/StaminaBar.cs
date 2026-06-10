using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

        public void ChangeMaxStamina (float maxStamina)
    {
        slider.maxValue  = maxStamina;
    }

    public void ChangeStamina (float currentStamina)
    {
        slider.value = currentStamina;
    }

    public void ResetStaminaBar()
    {
        slider.value = slider.maxValue;
    }
}
