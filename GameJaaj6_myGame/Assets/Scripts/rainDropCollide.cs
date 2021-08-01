using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainDropCollide : MonoBehaviour
{

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void OnParticleCollision(GameObject other)
    {
        Destroy(ps,0);
    }

}
