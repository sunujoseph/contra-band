using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    GameObject obj;

    // Update is called once per frame
    void Update()
    {
        obj = GetComponent<GameObject>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(obj);
        }
    }
        
    

}


