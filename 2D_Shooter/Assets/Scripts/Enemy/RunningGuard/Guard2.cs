using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard2 : MonoBehaviour
{
    int _Health = 1;

    private void Update()
    {
        if (_Health < 1)
        {
            Die();
        }
    }

    public void TakeDmg(int dmg)
    {
        _Health -= dmg;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public int GetHP()
    {
        return _Health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet" && GetComponent<Renderer>().isVisible)
        {
            //TakeDmg(collision.gameObject.GetComponent<PlayerBullet>().GetBulletDmg());
        }
    }
}
