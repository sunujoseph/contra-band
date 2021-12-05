using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{

    int maxHealth;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
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
