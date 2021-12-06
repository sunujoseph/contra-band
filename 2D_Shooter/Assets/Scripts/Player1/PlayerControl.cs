using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Transform trans;
    Rigidbody2D body;
    Animator anim;

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] float _bulletSpeed;
    [SerializeField] float _shootDelay;

    bool _jumpInput;
    bool isGrounded;

    //bool isWalking;

    float timeToNextShot = 0;
    //float playerGravity = 15f;



    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();

        if (Input.GetKeyDown(KeyCode.K))
        {
            _jumpInput = true;

            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            _jumpInput = false;
            anim.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && CanShoot())
        {
            ShootDown();
            anim.SetBool("ShootUp", true);
        }

        if (Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.W) && CanShoot())
        {
            ShootUp();
            anim.SetBool("ShootUp", true);
        }

        if (Input.GetKeyUp(KeyCode.J) && Input.GetKeyUp(KeyCode.W) && CanShoot())
        {
            ShootUp();
            anim.SetBool("ShootUp", false);
        }




        if (Input.GetKey(KeyCode.J) && CanShoot() || Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.K) && CanShoot())
        {
            Shoot();
        }

        // check if mid air and have fallen through platform 
        if (isGrounded == false && gameObject.layer != 7)
        {
            gameObject.layer = 7;
            isGrounded = true;
        }

        // fall through platforms 
        if (isGrounded == true && Input.GetKey(KeyCode.S))
        {
            gameObject.layer = 8;
            isGrounded = false;
        }





    }

    void FixedUpdate()
    {
        if (_jumpInput && isGrounded)
        {
            Jump();
        }

    }



    void Walk()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Running", true);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Running", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Running", false);
        }

    }

    void Jump()
    {
        body.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        isGrounded = false;

    }

    void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * _bulletSpeed;

        Destroy(bullet, 10);
    }

    void ShootUp()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * _bulletSpeed;

        Destroy(bullet, 1);
    }

    void ShootDown()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * _bulletSpeed;

        Destroy(bullet, 1);

    }
    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup)
        {
            timeToNextShot = Time.realtimeSinceStartup + _shootDelay;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0.5)
                {
                    isGrounded = true;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.collider.tag == "Ground") 
        {
            
        }
    }
}

    // public float GetSpeed()

    //return _speed;


    // public bool GetIsWalking()

    //return isWalking;
    //public bool GetIsGrounded()

    // return isGrounded;


