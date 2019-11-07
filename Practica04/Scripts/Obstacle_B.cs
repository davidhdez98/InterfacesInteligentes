using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_B : MonoBehaviour
{
    void OnEnable()
    {
        DelegateHandler.Click2 += Cambiar_Color;
    }

    void Cambiar_Color()
    {
        Color color = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = color;
    }

    void OnDisable()
    {
        DelegateHandler.Click2 -= Cambiar_Color;
    }

}
