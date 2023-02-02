using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControls : MonoBehaviour
{
    //Outlet
    Rigidbody2D _rigidbody2d;
    SpriteRenderer playerSprite;
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

    //Player Animations
    public enum PlayerAnimationState {Standing, Walking, Jumping, Falling}
    public PlayerAnimationState currentAnimation;
    public Sprite[] playerFrames;
    int frameTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        cap2D = GetComponent<CapsuleCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
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

                if (_rigidbody2d.velocity.x > 1 || _rigidbody2d.velocity.x < -1)
                {
                    currentAnimation = PlayerAnimationState.Walking;
                }
                else
                {
                    currentAnimation = PlayerAnimationState.Standing;
                }
            }
            else
            {
                usableJumpSpeed = 0f;
                if (_rigidbody2d.velocity.y > 0)
                {
                    currentAnimation = PlayerAnimationState.Jumping;
                }
                else
                {
                    currentAnimation = PlayerAnimationState.Falling;
                }
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

            RunAnimations();
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
            playerSprite.flipX = true;
        }
        //Move Right
        if (Input.GetKey(keyRight))
        {
            _rigidbody2d.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            //transform.position += transform.right * (Time.deltaTime * speed);

            isRight = true; //Facing right, so dash will be to the right
            playerSprite.flipX = false;
        }
    }

    private bool IsGrounded()
    {
        float extra = 0;
        //RaycastHit2D rayHit =  Physics2D.Raycast(cap2D.bounds.center, Vector2.down, cap2D.bounds.extents.y + extra, groundLayerMask);
        //RaycastHit2D rayHit = Physics2D.BoxCast(cap2D.bounds.center, cap2D.bounds.size, 0f, Vector2.down, extra, groundLayerMask);
        RaycastHit2D rayHit = Physics2D.CapsuleCast(cap2D.bounds.center - new Vector3(0, .6f, 0), cap2D.bounds.size / 2, CapsuleDirection2D.Vertical, 0f, Vector2.down, extra, groundLayerMask);

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

    private void RunAnimations()
    {
        int frameLimit;
        switch (currentAnimation)
        {
            case PlayerAnimationState.Standing:
                playerSprite.sprite = playerFrames[0];
                frameTime = 0;
                break;
            case PlayerAnimationState.Walking:

                //frameTime: Tracks each frame of animation
                //frameLimit: Length of animation in frames
                frameLimit = 16;
                if (frameTime > 0)
                {
                    frameTime--;
                }
                else
                {
                    frameTime = frameLimit;
                }

                //Plays each frame of animation (Denominator is total number of frames, multiply it by however many frames are left)
                if (frameTime < (frameLimit/2) * 1)
                {
                    playerSprite.sprite = playerFrames[2];
                }
                else
                {
                    playerSprite.sprite = playerFrames[1];
                }
                break;
            case PlayerAnimationState.Jumping:
                playerSprite.sprite = playerFrames[3];
                frameTime = 0;
                break;
            case PlayerAnimationState.Falling:
                playerSprite.sprite = playerFrames[4];
                frameTime = 0;
                break;
        }
    }
}
