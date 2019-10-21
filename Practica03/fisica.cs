using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisica : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float avance;
    public float choques = 0;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avance = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(1, 0, 0) * avance, ForceMode.Acceleration);  
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(0, 0, 1) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector3(0, 0, -1) * avance, ForceMode.Acceleration);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            choques = choques + 1;    
            
        } 
    }

    
}
    