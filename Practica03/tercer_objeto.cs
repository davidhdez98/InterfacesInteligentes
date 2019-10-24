using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tercer_objeto : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float avance;
    public float choques_verde = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avance = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            rb.AddForce(new Vector3(1, 0, 0) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.J))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.I))
        {
            rb.AddForce(new Vector3(0, 0, 1) * avance, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.M))
        {
            rb.AddForce(new Vector3(0, 0, -1) * avance, ForceMode.Acceleration);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Player")
        {
            choques_verde = choques_verde + 1;

        }
    }

}