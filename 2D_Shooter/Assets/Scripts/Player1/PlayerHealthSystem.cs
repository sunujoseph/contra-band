using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthSystem : MonoBehaviour
{
    public int maxHealth, currentHealth;

    public GameObject HP1, HP2, HP3;

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

        switch (currentHealth)
        {
            case 3:
                HP3.SetActive(true);
                HP2.SetActive(false);
                HP1.SetActive(false);
                break;

            case 2:
                HP3.SetActive(false);
                HP2.SetActive(true);
                HP1.SetActive(false);
                break;

            case 1:
                HP3.SetActive(false);
                HP2.SetActive(false);
                HP1.SetActive(true);
                break;

            default:
                HP3.SetActive(false);
                HP2.SetActive(false);
                HP1.SetActive(false);
                break;
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }


    }
}
