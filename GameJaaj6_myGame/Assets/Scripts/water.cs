using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour

{
    private GameObject agua;
    private Vector3 scale;
    public float high = 3.6f;
    private bool touch;


    // Start is called before the first frame update
    void Start()
    {
        touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.localScale.y + high);
    }


    void OnParticleCollision(GameObject other)
    {
        touch = true;
        Invoke("teste", 0);
    }

    private void teste()
    {
        if (touch == true)
        {
            transform.localScale = new Vector3(7.11f, transform.localScale.y + high, 1);
            touch = false;
        }
        Debug.Log("Teste");
    }









}