using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{

    public Animator ani;
    private seasonManager season;

    void Start()
    {
        GameObject a = GameObject.FindGameObjectWithTag("Controller");
        season = a.GetComponent<seasonManager>();
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        autumn();
        spring();
        summer();
        winter();
    }

    private void autumn()
    {
        if (season.currentSeason == seasonManager.Season.AUTUMN)
        {
            ani.SetBool("Autumn", true);
            ani.SetBool("Summer", false);
            ani.SetBool("Spring", false);
            ani.SetBool("Winter", false);
        }
    }

    private void spring()
    {
        if (season.currentSeason == seasonManager.Season.SPRING)
        {
            ani.SetBool("Autumn", false);
            ani.SetBool("Summer", false);
            ani.SetBool("Spring", true);
            ani.SetBool("Winter", false);
        }
    }


    private void summer()
    {
        if (season.currentSeason == seasonManager.Season.SUMMER)
        {
            ani.SetBool("Autumn", false);
            ani.SetBool("Summer", true);
            ani.SetBool("Spring", false);
            ani.SetBool("Winter", false);
        }
    }

    private void winter()
    {
        if (season.currentSeason == seasonManager.Season.WINTER)
        {
            ani.SetBool("Autumn", false);
            ani.SetBool("Summer", false);
            ani.SetBool("Spring", false);
            ani.SetBool("Winter", true);
        }
    }
}

