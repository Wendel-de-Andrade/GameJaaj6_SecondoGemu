using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour

{
    private GameObject agua;
    private Vector3 scale;
    public float high = 3.6f;
    public static water instance;
    private bool block;

    // Start is called before the first frame update
    void Start()
    {
        block = false;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.localScale.y + high);

    }

    private void acionTrigger()
    {
        transform.localScale = new Vector3(7.11f, transform.localScale.y + high, 1);
        Debug.Log("Colidiu");
    }

    public void OnParticleCollision(GameObject other)
    {
        if (block == false)
        {
            acionTrigger();
        
        }


    }


}