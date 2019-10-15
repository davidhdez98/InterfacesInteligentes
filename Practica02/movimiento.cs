using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10f;
    public Vector3 rotar = new Vector3(0f, 0f, -1f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) )
        {
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) )
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) )
        {
            transform.Rotate(Vector3.down,  speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left, speed * Time.deltaTime);
        }

    }
}
