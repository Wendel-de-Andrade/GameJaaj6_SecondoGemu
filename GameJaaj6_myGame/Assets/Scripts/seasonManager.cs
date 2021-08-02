using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasonManager : MonoBehaviour
{
    //Definindo estações
    public enum Season { NONE, SPRING, SUMMER, AUTUMN, WINTER };
    public Season currentSeason;
    //Chamando estações
    //Inverno
    [SerializeField] ParticleSystem neve = null;
    private water agua;

    void Start()
    {
        GameObject a = GameObject.FindGameObjectWithTag("Agua");
        agua = a.GetComponent<water>();
    }
    void Update()
    {
        winter();
    }

    public void winter()
    {
        if (currentSeason == Season.WINTER)
        {
            neve.Play();
            agua.winter = true;
        }

        if (currentSeason != Season.WINTER)
        {
            neve.Stop();
            agua.winter = false;
        }
    }
}
