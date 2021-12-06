using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadout : MonoBehaviour
{
     float shootDelay;


    [SerializeField] GameObject FlamePrefab;
    [SerializeField] GameObject RocketPrefab;
    [SerializeField] GameObject LaserPrefab;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject PlasmaPrefab;
    [SerializeField] GameObject ShotGunPrefab;
    [SerializeField] GameObject triGunPrefab;



    [SerializeField] Transform bulletSpawn;

     float bulletSpeed = 20;


    int itemIndex = 1;
    
    float timebetweenshots = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemIndex == 1 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootRegular();
        }
        if (itemIndex == 2 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootRocket();
        }
        if (itemIndex == 3 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootShotGun();
        }
        if (itemIndex == 4 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootPlasma();
        }
        if (itemIndex == 5 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootTri();
        }
        if (itemIndex == 6 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootLaser();
        }
        if (itemIndex == 7 && Input.GetKey(KeyCode.J) && CanShoot())
        {
            ShootFlame();
        }
    }

    void ShootRegular()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 5);
    }

    void ShootFlame()
    {
        var bullet = Instantiate(FlamePrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 100)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 0.8f);
    }

    void ShootTri()
    {

        var bulletMid = Instantiate(triGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bulletUp = Instantiate(triGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bulletDown = Instantiate(triGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bulletUp.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1, 0.7f, 0) * bulletSpeed;
        bulletMid.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        bulletDown.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1, -0.3f, 0) * bulletSpeed;

        Destroy(bulletUp, 5);
        Destroy(bulletDown, 5);
        Destroy(bulletMid, 5);
    }

    void ShootShotGun()
    {

        var bullet1 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet2 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet3 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet4 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet5 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet6 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet7 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet8 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet9 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        var bullet10 = Instantiate(ShotGunPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet1.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, .59f, 0) * bulletSpeed;
        bullet2.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, 0, 0) * bulletSpeed;
        bullet10.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed / 1.3f;
        bullet3.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1, -.095f, 0) * bulletSpeed;
        bullet4.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, -0.092f, 0) * bulletSpeed;
        bullet5.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, .102f, 0) * bulletSpeed;
        bullet6.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, -.095f, 0) * bulletSpeed;
        bullet7.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, 0.497f, 0) * bulletSpeed;
        bullet8.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1f, -.103f, 0) * bulletSpeed;
        bullet9.GetComponent<Rigidbody2D>().velocity = transform.position + new Vector3(1, 0.398f, 0) * bulletSpeed;

        Destroy(bullet1, 0.5f);
        Destroy(bullet2, 0.5f);
        Destroy(bullet3, 0.5f);
        Destroy(bullet4, 0.5f);
        Destroy(bullet5, 0.5f);
        Destroy(bullet6, 0.5f);
        Destroy(bullet7, 0.5f);
        Destroy(bullet8, 0.5f);
        Destroy(bullet9, 0.5f);
        Destroy(bullet10, 0.5f);
    }

    void ShootRocket()
    {
        var bullet = Instantiate(RocketPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 5);
    }

    void ShootLaser()
    {
        var bullet = Instantiate(LaserPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 10);
    }

    void ShootPlasma()
    {
        var bullet = Instantiate(PlasmaPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 10);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RocketPower")
        {
            itemIndex = 2;
            timebetweenshots = 1.5f;
            shootDelay = 1.5f;
            float bulletSpeed = 8;
        }
        if (collision.gameObject.name == "ShotGunPower")
        {
            itemIndex = 3;
            timebetweenshots = 0.7f;
            shootDelay = .7f;
            float bulletSpeed = 15;
        }
        if (collision.gameObject.name == "PlasmaPower")
        {
            itemIndex = 4;
            timebetweenshots = 1;
            shootDelay = 1f;
            float bulletSpeed = 6f;
        }
        if (collision.gameObject.name == "TriPower")
        {
            itemIndex = 5;
            timebetweenshots = 0.3f;
            shootDelay = 0.3f;
            float bulletSpeed = 13f;
        }
        if (collision.gameObject.name == "LaserPower")
        {
            itemIndex = 6;
            timebetweenshots = 0.01f;
            shootDelay = 0.01f;
            float bulletSpeed = 100f;
        }
        if (collision.gameObject.name == "FlamePower")
        {
            itemIndex = 7;
            timebetweenshots = 0.07f;
            shootDelay = 0.07f;
            float bulletSpeed = 32f;
        }
        if (collision.gameObject.name == "MachinePower")
        {
            itemIndex = 1;
            timebetweenshots = 0.1f;
            shootDelay = 0.1f;
            float bulletSpeed = 20f;
        }
    }
    bool CanShoot()
    {
        if (timebetweenshots < Time.realtimeSinceStartup)
        {
            timebetweenshots = Time.realtimeSinceStartup + shootDelay;
            return true;
        }
        else
        {
            return false;
        }
    }
}

