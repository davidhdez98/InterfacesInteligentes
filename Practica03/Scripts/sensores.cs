using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensores : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstaculo" || other.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material.color = new Color32(255, 123, 4, 246);       
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material.color = Color.red;         
        }
    }

    
}
