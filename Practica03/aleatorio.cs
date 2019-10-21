using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aleatorio : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public float timeToDirectionChange = 1; 
    public float moveSpeed = 10;
    public float lastDirectionChange = 0;
    public Vector3 randomDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() 
    {
        if (Time.time - lastDirectionChange > timeToDirectionChange)
        {
            randomDirection = new Vector3(Random.onUnitSphere.x * 2, 0, Random.onUnitSphere.z * 2); // genera una posición nueva, aleatoriamente
            lastDirectionChange = Time.time;
        }
        // aplica la dirección en cada frame al rigidbody
        rb.MovePosition(rb.position + randomDirection * Time.fixedDeltaTime * moveSpeed);  
    }



}
