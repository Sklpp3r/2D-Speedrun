using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementspeed = 2.0f;
    private float jump = 5.0f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
        transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A)) 
        {
        transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space))
        {
        transform.Translate(Vector3.up * jump * Time.deltaTime);
        }
        
    }
}
