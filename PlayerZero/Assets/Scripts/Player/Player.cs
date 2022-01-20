
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
    //Movement Parameters
    private float vInput;
    private float hInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isWalking;
    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody rigidBody;

    private Direction playerDirection;

    private float movementSpeed;

    private bool _playerInputIsDisabled = false;

    public bool PlayerInputIsDisabled {get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }

    protected override void Awake()
    {
        base.Awake();
        
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        #region Player Input

        ResetAnimationTriggers();

        PlayerMovementInput();

        //PlayerWalkInput();

        EventHandler.CallMovementEvent(vInput, hInput, isWalking, isIdle, isCarrying,
                        toolEffect,
                        false,false,false,false);

        #endregion
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 move = new Vector3(hInput * movementSpeed * Time.deltaTime, 0,vInput * movementSpeed * Time.deltaTime);

        rigidBody.MovePosition(rigidBody.position + move);
    }

    private void ResetAnimationTriggers()
    {
        //ยังไม่ได้ใช้
    }

    private void PlayerMovementInput()
    {
        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        if(vInput != 0 && hInput != 0)
        {
            vInput = vInput *0.5f ;
            hInput = hInput *0.5f ;
        }

        if (hInput != 0 || vInput != 0)
        {
            //isRunning = true;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            //Capture player direction for save game
            if (hInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (hInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if (vInput < 0)
            {
                playerDirection = Direction.down;
            }
            else
            {
                playerDirection = Direction.up;
            }
        }
        else if (hInput == 0 && vInput == 0)
        {
            //isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }

    private void PlayerWalkInput()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //isRunning = false;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            //isRunning = true;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }
}
