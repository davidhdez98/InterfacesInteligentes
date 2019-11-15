using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour
{

    public delegate void ButtonClick();
    public static event ButtonClick DisparoA;
    public static event ButtonClick DisparoB;
    


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstaculo_Tipo_A")
        {
            DisparoA();            
        }

        if (collision.gameObject.tag == "Obstaculo_Tipo_B")
        {           
            DisparoB();
        }
         
    }
    
}
