using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour

{
    public float high;
    public static water instance;
    private Vector3 endScale;
    private Vector3 startScale;
    public bool winter = false;
    //Definido cores
    Renderer agua;
    //Cor da Água
    [SerializeField] [Range(0f, 1f)] float LerpTime;
    [SerializeField] Color myColor;
    //Estado da água
    public bool freeze;

    // Start is called before the first frame update
    void Start()
    {
        agua = GetComponent<Renderer>();
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
        if (winter == true)
        {
            Debug.Log("Foi");
            agua.material.color = Color.Lerp(agua.material.color, myColor, LerpTime);
            freeze = true;
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
        acionTrigger();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" && !freeze)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}