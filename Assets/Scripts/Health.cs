using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject deathVFX;

    float fullHealth;

    private void Start()
    {
        fullHealth = health;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        var healthSlider = GetComponentInChildren<Slider>();
        if (healthSlider)
        {
            healthSlider.value = health / fullHealth;
        }
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        UpdateHealthDisplay();
        if (health <= 0)
        {
            TriggetDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggetDeathVFX()
    {
        if (deathVFX)
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 1f);
        }
    }
}
