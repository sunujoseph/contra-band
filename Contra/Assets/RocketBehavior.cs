using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject rocketprefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") 
        { 
        Instantiate(prefab,transform.position, Quaternion.identity);
        Destroy(rocketprefab);
        }
    }

    
}
