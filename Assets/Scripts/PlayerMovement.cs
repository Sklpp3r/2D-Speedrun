
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] Rigidbody2D myRB;

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
            Flip();
        }

    }

    void FixedUpdate()
    {
        Animasyonlar();
        RunTurn();
        IsGrounded();
    }




    #region Flip Gravity

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
        jump *= -1;
        maxFlip--;
        myRB.gravityScale *= -1;

    }
    #endregion

    #region Karater saga sola donus

    void RunTurn()
    {

        float scaleDirection = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;

        if (scaleDirection != 0f)
        {
            Vector2 Scaler = transform.localScale;
            Scaler.x = scaleDirection;
            transform.localScale = Scaler;
        }

    }
    #endregion

    #region Animasyonlar

    void Animasyonlar()
    {
        MovementState state;

        state = (_horizontal != 0 && IsGrounded() == true) ? MovementState.Running :
        (myRB.velocity.y > 0.1f) ? MovementState.Jumping :
        (myRB.velocity.y < -0.1f) ? MovementState.Falling :
        MovementState.Idle;

        myAnimator.SetInteger("state", (int)state);

    }
    #endregion

    #region Groundcheck

    bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundSensorTransform.position, 0.15f, groundLayer);
        return isGrounded;
    }
    #endregion

}
