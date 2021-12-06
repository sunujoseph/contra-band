using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetView;

    [SerializeField] float maxUp, maxDown, maxLeft, maxRight;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Follow target's x position

        transform.position = targetView.position + offset;

        //transform.position = new Vector3(targetView.position.x, transform.position.y, transform.position.z);
    }
}
