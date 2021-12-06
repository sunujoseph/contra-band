using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard2Movement : MonoBehaviour
{
    Rigidbody2D guardBody;

    [SerializeField] Transform player1Trans;
    [SerializeField] float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        guardBody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(player1Trans.position.x - transform.position.x) < 22f)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        guardBody.velocity = new Vector2(-horizontalMovement, guardBody.velocity.y);

    }
}

