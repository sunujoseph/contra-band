using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] float shootDelay;


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed;

    [SerializeField] GameObject Exprefab;

    float timeToNextShot = 3;

    RocketBehavior IsExploding;

    void Start()
    {
        IsExploding = GetComponent<RocketBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && CanShoot())
        {
            ShootBullet();
        }
    }
    public void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 5);
    }
    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup)
        {
            timeToNextShot = Time.realtimeSinceStartup + shootDelay;
            return true;
        }
        else
        {
            return false;
        }

        

    }

}

    