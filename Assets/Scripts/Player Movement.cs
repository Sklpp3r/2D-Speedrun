using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] Rigidbody2D myRB;

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jump = 8.0f;
    [SerializeField] private int maxJumps = 2;

    [SerializeField] private Transform groundSensorTransform;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator myAnimator;




    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {




        //Movement
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jump);
        }

       




        //Ters Dönme
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            myRB.gravityScale *= -1;
            jump *= -1;
            Flip();
        }

    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;

    }

    void FixedUpdate()
    {
        Run();

        IsGrounded();
    }



    void Run()
    {
        //Kosma
        myRB.velocity = new Vector2(_horizontal * speed, myRB.velocity.y);


        //Karakter saga sola donus
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 Scaler = transform.localScale;
            Scaler.x = -1;
            transform.localScale = Scaler;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 Scaler = transform.localScale;
            Scaler.x = 1;
            transform.localScale = Scaler;
        }

        //Kosma animasyonu
        if (_horizontal != 0)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }


    }


    bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundSensorTransform.position, 0.15f, groundLayer);
        return isGrounded;
    }


}
