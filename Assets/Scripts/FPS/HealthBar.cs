using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using FPS;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    void Update()
    {
        healthText.text = GameManager.CurrentHealth.ToString();
        slider.value = GameManager.CurrentHealth;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    // Start is called before the first frame update
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
