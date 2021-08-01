using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour

{
    public float high = 3.6f;
    public static water instance;
    private bool block;
    private Vector3 endScale;
    private Vector3 startScale;
    public float duracao = 1.5f;
    public float tempoCorrido;
    private Transform agua;


    // Start is called before the first frame update
    void Start()
    {
        block = false;
        instance = this;
        endScale = new Vector3(transform.localScale.x, transform.localScale.y + high, 1);
        startScale = transform.localScale;
    }

    private void acionTrigger()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + high, 1);
        
        //tempoCorrido += Time.deltaTime;
        //float percentageComplete = tempoCorrido / duracao;

        //transform.localScale = Vector3.Lerp(startScale, endScale, percentageComplete);
        //transform.localScale = Vector3.Lerp(transform.localScale, endScale, Time.deltaTime);
        //transform.localScale = Vector3.Lerp(startScale, endScale,Mathf.SmoothStep(0, 1, percentageComplete));
    }

    public void OnParticleCollision(GameObject other)
    {
        if (block == false)
        {
            acionTrigger();

        }
    }


}