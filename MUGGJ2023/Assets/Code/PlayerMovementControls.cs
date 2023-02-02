using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControls : MonoBehaviour
{
    //Outlet
    Rigidbody2D _rigidbody2d;
    SpriteRenderer sprite;
    CapsuleCollider2D cap2D;

    //Layer Mask for ground
    [SerializeField] public LayerMask groundLayerMask;

    //KeyCodes
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public KeyCode keyJump;
    
    //Player movement speed
    public float speed;
    public float jumpSpeed;

    //State Tracking
    public bool isAlive;    //Check if the player is still alive
    public int jumpsLeft;   //Checks how many jumps are left
    public bool canRootSelf;    //Check if player can root into ground
    public bool isRight;    //Check if player is facing right (flip sprite)

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        cap2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float usableJumpSpeed;
            if (IsGrounded())
            {
                jumpsLeft = 1;
                usableJumpSpeed = jumpSpeed;
            }
            else
            {
                usableJumpSpeed = 0f;
            }

            //Jump
            if (Input.GetKeyDown(keyJump))
            {
                if (jumpsLeft > 0)
                {
                    float jumpDecrease;
                    jumpDecrease = 1.5f;
                    _rigidbody2d.AddForce(Vector2.up * ((jumpSpeed + usableJumpSpeed) / jumpDecrease), ForceMode2D.Impulse);
                    //_rigidbody2d.gravityScale = 10f;
                    if (!IsGrounded())
                    {
                        jumpsLeft--;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Move Left
        if (Input.GetKey(keyLeft))
        {
            _rigidbody2d.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            //transform.position -= transform.right * (Time.deltaTime * speed);

            isRight = false;    //Not facing right, so dash will be to the left
        }
        //Move Right
        if (Input.GetKey(keyRight))
        {
            _rigidbody2d.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            //transform.position += transform.right * (Time.deltaTime * speed);

            isRight = true; //Facing right, so dash will be to the right
        }
    }

    private bool IsGrounded()
    {
        float extra = 0;
        //RaycastHit2D rayHit =  Physics2D.Raycast(cap2D.bounds.center, Vector2.down, cap2D.bounds.extents.y + extra, groundLayerMask);
        //RaycastHit2D rayHit = Physics2D.BoxCast(cap2D.bounds.center, cap2D.bounds.size, 0f, Vector2.down, extra, groundLayerMask);
        RaycastHit2D rayHit = Physics2D.CapsuleCast(cap2D.bounds.center - new Vector3(0, .3f, 0), cap2D.bounds.size / 2, CapsuleDirection2D.Vertical, 0f, Vector2.down, extra, groundLayerMask);

        Color rayColor;
        if (rayHit.collider != null)
        {
            rayColor = Color.blue;
        }
        else
        {
            rayColor = Color.magenta;
        }

        //Debug.DrawRay(cap2D.bounds.center, Vector2.down * (cap2D.bounds.extents.y + extra), rayColor);
        return (rayHit.collider != null);
    }
}
