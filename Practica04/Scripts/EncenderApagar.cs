using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncenderApagar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Light>().enabled = true;       //enciende el foco
        }

        if (Input.GetKey(KeyCode.N))
        {
            GetComponent<Light>().enabled = false;      //apaga el foco
        }
    }
}
