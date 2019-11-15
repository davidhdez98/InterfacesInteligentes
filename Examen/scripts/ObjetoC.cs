using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoC : MonoBehaviour
{
    public float poder;
    public Rigidbody rb;
    public float avance;

    void Start()
    {
        poder = 0;
        rb = GetComponent<Rigidbody>();
        avance = 20;

    }
    void OnEnable()
    {
        DelegateHandler.DisparoB += Cambios;      
    }

    void Cambios()
    {
        rb.AddForce(new Vector3(0, 0, -1) * avance, ForceMode.Acceleration);
    }


    void OnDisable()
    {
        DelegateHandler.DisparoB -= Cambios;
    }

}