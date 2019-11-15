using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisica : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float avance;
    public float poder;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avance = 20;
        poder = 0;
    }

   /* void OnEnable()
    {
        DelegateHandler.Click += Incrementar_Poder;
        DelegateHandler.Click2 += Decrementar_Poder;
    }*/

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(0, 0, -1) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(0, 0, 1) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(1, 0, 0) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,0,0), ForceMode.Acceleration);
            rb.MovePosition(new Vector3(17, 0f, 15));

        }              

    }

    void Incrementar_Poder()
    {
        poder = poder + 1;
    }

    void Decrementar_Poder()
    {
        poder = poder - 1;
    }

  /*  void OnDisable()
    {
        DelegateHandler.Click -= Incrementar_Poder;
        DelegateHandler.Click2 -= Decrementar_Poder;
    }*/
}
