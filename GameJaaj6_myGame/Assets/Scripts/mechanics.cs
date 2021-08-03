using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mechanics : MonoBehaviour
{
    [SerializeField] ParticleSystem rain = null;
    public ParticleSystem trigger = null;
    public GameObject triggerObj;
    private bool acionado = false;
    static bool espera = false;
    private bool hover;
    public static mechanics instance;
    private water agua;

    //Verifica se a Nuvem já foi clicado e ativa ela

    void Start()
    {
        instance = this;
        hover = false;
        GameObject a = GameObject.FindGameObjectWithTag("Agua");
        agua = a.GetComponent<water>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && acionado == false && hover == true && agua.winter == false && espera == false)
        {
            Raining();
            acionado = true;
            StartCoroutine(acionamentoGlobal(0.88f));
        }
        if (agua.summer == true)
        {
            triggerObj.SetActive(true);
            acionado = false;
        }
    }

    IEnumerator acionamentoGlobal(float time)
    {
        espera = true;
        yield return new WaitForSeconds(time);
        espera = false;
    }

    //Metódo para chamar a chuva
    public void Raining()
    {
        rain.Play();
        trigger.Play();
    }

    //Verifica se o ponteiro do mouse entrou no Collider do Objeto
    void OnMouseEnter()
    {
        hover = true;
    }
    void OnMouseExit()
    {
        hover = false;
    }
}


