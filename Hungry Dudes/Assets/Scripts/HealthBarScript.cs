using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxHealth(int MaxHealth, int health)
    {
        slider.maxValue = MaxHealth;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
