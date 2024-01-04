 using System;
 using System.Collections;
using System.Collections.Generic;
 using Unity.VisualScripting;
 using UnityEngine;
 using UnityEngine.Serialization;

 public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Me;
   
    
    private float movementspeed = 6.0f;
    private float jump = 5.0f;

    private void Start()
    {
        Me = GetComponent<Rigidbody2D>();
    }


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

        if(Input.GetKey(KeyCode.Space) && Me.gravityScale == 1)
        {
        transform.Translate(Vector3.up * jump * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space) && Me.gravityScale == -1)
        {
                transform.Translate(Vector3.down * jump * Time.deltaTime);
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Me.gravityScale *= -1;
            Flip();
        }
        
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
        
    }
    
    
}