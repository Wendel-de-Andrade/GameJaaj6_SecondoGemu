using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mechanics : MonoBehaviour
{
    [SerializeField] ParticleSystem rain = null;
    public ParticleSystem trigger = null;
    public bool acionado = false;
    private bool hover;
    public static mechanics instance;

    //Verifica se a Nuvem já foi clicado e ativa ela

    void Start()
    {
        instance = this;
        hover = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && acionado == false && hover == true)
        {
            Raining();
            acionado = true;
        }
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


