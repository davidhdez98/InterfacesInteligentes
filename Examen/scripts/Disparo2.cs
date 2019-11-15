using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo2 : MonoBehaviour
{
    public float poder;

    void Start()
    {
        poder = 0;
    }
    void OnEnable()
    {
        DelegateHandler.DisparoB += Cambios;
    }

    void Cambios()
    {

        if (Input.GetKey(KeyCode.N))
        {
            poder = poder - 1;
        }

        if (Input.GetKey(KeyCode.M))
        {
            Color color = new Color(Random.value, Random.value, Random.value);
            GetComponent<Renderer>().material.color = color;
        }

    }

    void OnDisable()
    {
        DelegateHandler.DisparoB -= Cambios;
    }

}