using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainDropCollide : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        gameObject.SetActive(false);
    }
}
