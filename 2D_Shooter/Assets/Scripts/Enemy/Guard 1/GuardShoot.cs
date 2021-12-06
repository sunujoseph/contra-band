using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShoot : MonoBehaviour
{
    [SerializeField] Transform player1Trans;
    [SerializeField] GameObject bulletPF;
    [SerializeField] float bulletSpeed;


    Animator anim;

    Renderer renderer;

    

    float TimeToNextShot = 0;
    float shootingDelay = 3f;

    bool InitalDelayApplied;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        if (CanShoot())
        {
            Shoot();

        }
        if (!InitalDelayApplied && renderer.isVisible)
        {
            TimeToNextShot = Time.realtimeSinceStartup + 1f;
            InitalDelayApplied = true;
        }

    }

    void Shoot()
    {

        var bullet = Instantiate(bulletPF, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = (player1Trans.position - transform.position).normalized * bulletSpeed;

        Destroy(bullet, 5);
    }

    bool CanShoot()
    {
        if (TimeToNextShot < Time.realtimeSinceStartup && renderer.isVisible)
        {
            TimeToNextShot = Time.realtimeSinceStartup + shootingDelay;

            return true;
        }
        else
        {
            return false;
        }
    }
}
