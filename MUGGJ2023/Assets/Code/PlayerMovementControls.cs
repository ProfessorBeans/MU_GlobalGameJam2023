using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovementControls : MonoBehaviour
{
    //Outlet
    Rigidbody2D _rigidbody2d;
    SpriteRenderer playerSprite;
    CapsuleCollider2D cap2D;
    public GameObject _mainCam;
    private Scene _scene;

    public AudioManager _audioManager;

    //Layer Masks for ground & dirt mound
    [SerializeField] public LayerMask groundLayerMask;

    //KeyCodes
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public KeyCode keyJump;
    public KeyCode keyReset;

    //Player movement speed
    public float speed;
    public float jumpSpeed;

    //State Tracking
    public bool isAlive;    //Check if the player is still alive
    public int jumpsLeft;   //Checks how many jumps are left
    public bool canRootSelf;    //Check if player can root into ground
    public bool isRooted;   //Check if player is currently rooted
    public bool isRight;    //Check if player is facing right (flip sprite)
    public float resetTimer;

    //Player Animations
    public enum PlayerAnimationState { Standing, Walking, Jumping, Falling, Rooted }
    public PlayerAnimationState currentAnimation;
    public Sprite[] playerFrames;
    public float frameTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        cap2D = GetComponent<CapsuleCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        canRootSelf = false;
        isRooted = false;
        resetTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (!isRooted)
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
                    _audioManager.playJumpVoice();
                    
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

                if(canRootSelf)
                {
                    if (Input.GetKeyDown(keyDown))
                    {
                        isRooted = true;
                        
                        _audioManager.playMoundVoice();
                    }
                }

            }
            else
            {
                currentAnimation = PlayerAnimationState.Rooted;
            }

            RunAnimations();
        }

        if(Input.GetKey(keyReset))
        {
            resetTimer += Time.deltaTime;
            if (resetTimer > 3.0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        else
        {
            resetTimer = 0.0f;
        }
    }

    void FixedUpdate()
    {
        if (!isRooted)
        {
            //Move Left
            if (Input.GetKey(keyLeft))
            {
                _rigidbody2d.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
                //transform.position -= transform.right * (Time.deltaTime * speed);

                isRight = false;    //Not facing right, so dash will be to the left
                playerSprite.flipX = true;
                
                _audioManager.playWalking();
            }
            //Move Right
            if (Input.GetKey(keyRight))
            {
                _rigidbody2d.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
                //transform.position += transform.right * (Time.deltaTime * speed);

                isRight = true; //Facing right, so dash will be to the right
                playerSprite.flipX = false;
                
                _audioManager.playWalking();
            }
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
        float frameLimit;
        switch (currentAnimation)
        {
            case PlayerAnimationState.Standing:
                playerSprite.sprite = playerFrames[0];
                frameTime = 0.0f;
                break;
            case PlayerAnimationState.Walking:

                //frameTime: Tracks each frame of animation
                //frameLimit: Length of animation in frames
                frameLimit = .4f;
                if (frameTime > 0.0f)
                {
                    frameTime -= Time.deltaTime;
                }
                else
                {
                    frameTime = frameLimit;
                }

                //Plays each frame of animation (Denominator is total number of frames, multiply it by however many frames are left)
                if (frameTime < (frameLimit / 2.0f) * 1.0f)
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
            case PlayerAnimationState.Rooted:
                playerSprite.sprite = playerFrames[5];
                frameTime = 0;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //print("On Mound");
            canRootSelf = true;
            _mainCam.GetComponent<MainCamControls>().PanToRoots();
        }
        
        if (collision.GetComponent<CapsuleCollider2D>())
        {
            print("oh he dead");
            _audioManager.playDieVoice();
            Scene _scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(_scene.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //print("Off Mound");
            canRootSelf = false;
            _mainCam.GetComponent<MainCamControls>().PanToSeedBoy();
        }
    }
}
