using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    [SerializeField]
    private float time;

    void Start()
    {
        Destroy(gameObject, time);
    }

}
