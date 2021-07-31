using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mechanics : MonoBehaviour
{
    [SerializeField] ParticleSystem rain = null;
    public bool acionado = false;
    private bool hover;
    private ParticleSystem particles;
    public int qntParticles;
    public static mechanics instance;

    //Verifica se a Nuvem já foi clicado e ativa ela

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        instance = this;
        hover = false;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && acionado == false && hover == true)
        {
            {
                Debug.Log("CLICKED " + particles);
                Raining();
                acionado = true;
            }
        }

    }

    //Metódo para chamar a chuva
    public void Raining()
    {
        rain.Play();
    }

    //Verifica se o ponteiro do mouse entro no Collider do Objeto
    void OnMouseEnter()
    {
        hover = true;
    }
    void OnMouseExit()
    {
        hover = false;
    }
}
