using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int maxHealth, currentHealth;

    GameObject healthBar;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void DamageHealth()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
