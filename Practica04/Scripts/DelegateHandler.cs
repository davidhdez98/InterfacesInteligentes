using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour
{

    public delegate void ButtonClick();
    public static event ButtonClick Click;
    public static event ButtonClick Click2;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstaculo_Tipo_A")
        {
            Click();
        }

        if (collision.gameObject.tag == "Obstaculo_Tipo_B")
        {
            Click2();
        }
         
    }
    
}
