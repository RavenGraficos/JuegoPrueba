using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Slider slider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

        public void ChangeMaxHealth (float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeHealth (float currentHealth)
    {
        slider.value = currentHealth;
    }

    public void ResetHealthBar()
    {
        slider.value = slider.maxValue;
    }

}
