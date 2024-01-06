using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class Player_Movement : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] Rigidbody2D myRB;//

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jump = 7.0f;
    [SerializeField] private int maxJumpValue = 1;
    [SerializeField] private int maxJump;
    [SerializeField] private int maxFlipValue = 1;
    [SerializeField] private int maxFlip;


    [SerializeField] private Transform groundSensorTransform;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator myAnimator;

    enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }


    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        maxJump = maxJumpValue;
        maxFlip = maxFlipValue;
    }


    // Update is called once per frame
    void Update()
    {

        //Movement
        _horizontal = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(_horizontal * speed, myRB.velocity.y);

        //Jump ve double jump
        if (IsGrounded() == true)
        {
            maxFlip = maxFlipValue;
            maxJump = maxJumpValue;
        }
        if (Input.GetButtonDown("Jump") && maxJump > 0)
        {
            maxJump--;
            myRB.velocity = Vector2.up * jump;
        }


        //Ters Dönme
        if (Input.GetKeyDown(KeyCode.Mouse0) && maxFlip > 0)
        {
            
            maxFlip--;
            myRB.gravityScale *= -1;
            jump *= -1;
            Flip();
        }

    }

     void FixedUpdate()
    {
        Animasyonlar();
        RunTurn();
        IsGrounded();
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;

    }

    void RunTurn()
    {
       
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

    }


    bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundSensorTransform.position, 0.15f, groundLayer);
        return isGrounded;
    }

    void Animasyonlar()
    {
        MovementState state;

        //Kosma animasyonu
        if (_horizontal > 0)
        {
            state = MovementState.Running;
        }
        else if (_horizontal < 0)
        {
            state = MovementState.Running;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (myRB.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (myRB.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        myAnimator.SetInteger("state", (int)state);


    }

}
