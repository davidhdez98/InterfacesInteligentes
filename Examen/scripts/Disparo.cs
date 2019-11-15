using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float poder;
    public Rigidbody rb;

    void Start()
    {
        poder = 0;
    }
    void OnEnable()
    {
        DelegateHandler.DisparoA += Cambios;        
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
            DelegateHandler.DisparoA -= Cambios;
        }   

}
