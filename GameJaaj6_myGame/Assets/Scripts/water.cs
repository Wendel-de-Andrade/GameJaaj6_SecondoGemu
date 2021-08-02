using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour

{
    public float high;
    public static water instance;
    private Vector3 endScale;
    private Vector3 startScale;
    private GameObject waterObj;
    private SpriteRenderer waterSprite;
    public int qtdAcion = 0;
    private bool reduce = false;
    //Estações
    public bool winter = false;
    public bool summer = false;
    //Definido cores
    Renderer render;
    [SerializeField] [Range(0f, 1f)] float LerpTime;
    [SerializeField] Color myColorPrimary;
    [SerializeField] Color myColorSecondary;
    //Estado da água
    public bool freeze;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        instance = this;
        endScale = new Vector3(transform.localScale.x, transform.localScale.y + high, 1);
        startScale = transform.localScale;
        waterSprite = GetComponent<SpriteRenderer>();
        waterSprite.material.color = myColorPrimary;
    }
    void Update()
    {
        winterSeason();
        summerSeason();
    }

    private void winterSeason()
    {
        if (winter == true)
        {
            render.material.color = Color.Lerp(render.material.color, myColorSecondary, LerpTime);
            freeze = true;
        }
    }

    private void summerSeason()
    {
        if (summer == true)
        {
            render.material.color = Color.Lerp(render.material.color, myColorPrimary, LerpTime);
            freeze = false;
            if (reduce == true)
            {
                transform.localScale = new Vector3(transform.localScale.x, (high*qtdAcion)-transform.localScale.y, 1);
                reduce = false;
                qtdAcion = 0;
            }
        }
    }
    private void acionTrigger()
    {
        if (summer == true)
        {

        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + high, 1);
            reduce = true;
        }


        //tempoCorrido += Time.deltaTime;
        //float percentageComplete = tempoCorrido / duracao;

        //transform.localScale = Vector3.Lerp(startScale, endScale, percentageComplete);
        //transform.localScale = Vector3.Lerp(transform.localScale, endScale, Time.deltaTime);
        //transform.localScale = Vector3.Lerp(startScale, endScale,Mathf.SmoothStep(0, 1, percentageComplete));
    }
    public void OnParticleCollision(GameObject other)
    {
        acionTrigger();
        qtdAcion = ++qtdAcion;
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" && !freeze)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}