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
    public bool winter = false;
    //Definido cores
    Renderer agua;
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    float duration = 1.0f;
    //Verificação
    private bool canRun = false;

    // Start is called before the first frame update
    void Start()
    {
        agua = GetComponent<Renderer>();
        block = false;
        instance = this;
        endScale = new Vector3(transform.localScale.x, transform.localScale.y + high, 1);
        startScale = transform.localScale;
    }

    void Update()
    {
        winterSeason();
    }

    private void winterSeason()
    {
        while (canRun == true)
        {
            if (winter == true)
            {
                Debug.Log("Foi");
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                agua.material.color = Color.Lerp(colorStart, colorEnd, lerp);
                canRun = false;
            }
        }
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

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }


}