using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour

{
    public float high;
    public static water instance;
    private SpriteRenderer waterSprite;
    private int qtdAcion = 0;
    private bool reduce = false;
    public AnimationCurve curve;
    //Estações
    public bool winter = false;
    public bool summer = false;
    public bool spring = false;
    public bool autumn = false;
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
        waterSprite = GetComponent<SpriteRenderer>();
        waterSprite.material.color = myColorPrimary;
    }
    void Update()
    {
        winterSeason();
        summerSeason();
        springSeason();
        autumnSeason();
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
                StartCoroutine(ScaleSummerAnimation(1.0f));
                reduce = false;
                qtdAcion = 0;
            }
        }
    }

    private void springSeason()
    {
        if (spring == true)
        {
            render.material.color = Color.Lerp(render.material.color, myColorPrimary, LerpTime);
            freeze = false;
        }
    }

    private void autumnSeason()
    {
        if (autumn == true)
        {
            render.material.color = Color.Lerp(render.material.color, myColorPrimary, LerpTime);
            freeze = false;
        }
    }

    IEnumerator ScaleAnimation(float time)
    {
        float i = 0;
        float rate = 1 / time;

        Vector3 fromScale = transform.localScale;
        Vector3 toScale = new Vector3(transform.localScale.x, transform.localScale.y + high, 1);
        {
            while (i < 1)
            {
                i += Time.deltaTime * rate;
                transform.localScale = Vector3.Lerp(fromScale, toScale, curve.Evaluate(i));
                yield return 0;
            }
        }
    }

    IEnumerator ScaleSummerAnimation(float time)
    {
        float i = 0;
        float rate = 1 / time;

        Vector3 fromScale = transform.localScale;
        Vector3 toScale2 = new Vector3(transform.localScale.x, transform.localScale.y - (high * qtdAcion), 1);
        {
            while (i < 1)
            {
                i += Time.deltaTime * rate;
                transform.localScale = Vector3.Lerp(fromScale, toScale2, curve.Evaluate(i));
                yield return 0;
                Debug.Log("ACESSOU_Summer");
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
            StartCoroutine(ScaleAnimation(1.0f));
            reduce = true;
            qtdAcion = ++qtdAcion;
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        acionTrigger();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" && !freeze)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"), 0.0025f);
        }
    }
}