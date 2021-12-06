using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject esplode;
    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (render.isVisible)
        {
            Destroy(esplode, 0.3f);
        }
    }
}
