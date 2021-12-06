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

    // Update is called once per frame
    void Update()
    {
        Walk();
    
        if (Input.GetKeyDown(KeyCode.W))
        {  
            _jumpInput = true;

            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _jumpInput = false;       
            anim.SetBool("Jump", false);
        }
        
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S) && CanShoot())
        {
            ShootDown();
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && CanShoot())
        {
            ShootDiagonalUpRight();
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && CanShoot())
        {
            ShootDiagonalUpRight();
        }
            if (Input.GetKey(KeyCode.Space) && CanShoot())
            {
                Shoot();
            }


        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && CanShoot())
        {
            ShootDiagonalDownRight();    
        }
        // check if mid air and have fallen through platform
        if (isGrounded == false && gameObject.layer != 7)
        {
            gameObject.layer = 7;
            isGrounded = true;
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && CanShoot())
        {
            ShootDiagonalDownLeft();
        }
        // fall through platforms
        if (isGrounded == true && Input.GetKey(KeyCode.S))
        {
            gameObject.layer = 8;
            isGrounded = false;
        }


        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W)&& CanShoot())
        {
            ShootUp();
        }
        if (Input.GetKey(KeyCode.Space) && CanShoot())  
        {
            Shoot();   
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


        //if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //isWalking = false;
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

        bullet.GetComponent<Rigidbody2D>().velocity= transform.right * _bulletSpeed;

        Destroy(bullet, 1);
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
    void ShootDiagonalUpRight()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = (transform.up + transform.right) * _bulletSpeed;

        Destroy(bullet, 1);
    }

    void ShootDiagonalUpLeft()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = (transform.up + -transform.right) * _bulletSpeed;

        Destroy(bullet, 1);
    }


    void ShootDiagonalDownRight()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = (-transform.up + transform.right) * _bulletSpeed;

        Destroy(bullet, 1);
    }
     void ShootDiagonalDownLeft()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = (-transform.up + -transform.right) * _bulletSpeed;

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




     // public float GetSpeed()
    
     //return _speed;
    

    // public bool GetIsWalking()
   
    //return isWalking;
    //public bool GetIsGrounded()

    // return isGrounded;


}
  

