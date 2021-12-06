using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetView;

    [SerializeField] float minX, maxX, minY, maxY;

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

        float cutoffX = Mathf.Clamp(transform.position.x, minX, maxX);
        float cutoffY = Mathf.Clamp(transform.position.y, minY, maxX);

        transform.position = new Vector3(cutoffX, cutoffY, transform.position.z) + offset;
    }
}
 