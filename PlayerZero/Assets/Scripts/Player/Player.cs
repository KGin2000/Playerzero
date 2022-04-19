using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
    [SerializeField] GameObject GetAnimator;
    [SerializeField] GameObject PlayerObject;
    public Vector3 PlayerPosition;
    public Vector3 MPosition;
    private AnimationOverrides animationOverrides;
    private WaitForSeconds afterLiftToolAnimationPause;
    private WaitForSeconds afterUseToolAnimationPause;
    private WaitForSeconds afterPickAnimationPause;
    private GridCursor gridCursor;
    private Cursor cursor;

    //Movement Parameters
    private float vInput;
    private float hInput;
    private bool PlayerDead;
    private bool PlayerExhausted;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isWalking;

    private bool isUsingMiningToolUp;
    private bool isUsingMiningToolDown;
    private bool isUsingMiningToolLeft;
    private bool isUsingMiningToolRight;
    private bool isUsingChoppingToolUp;
    private bool isUsingChoppingToolDown;
    private bool isUsingChoppingToolLeft;
    private bool isUsingChoppingToolRight;
    private bool isUsingDiggingToolUp;
    private bool isUsingDiggingToolDown;
    private bool isUsingDiggingToolLeft;
    private bool isUsingDiggingToolRight;
    private bool isUsingLiftingToolUp;
    private bool isUsingLiftingToolDown;
    private bool isUsingLiftingToolLeft;
    private bool isUsingLiftingToolRight;
    private bool isUsingSwingingToolUp;
    private bool isUsingSwingingToolDown;
    private bool isUsingSwingingToolLeft;
    private bool isUsingSwingingToolRight;

    private WaitForSeconds liftToolAnimationPause;
    private WaitForSeconds pickAnimationPause;
    
    private Camera mainCamera;  //26//
    private bool playerToolUseDisabled = false;

    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody rigidBody;
    private WaitForSeconds useToolAnimationPause;
    private Direction playerDirection;

    private List<CharacterAttribute> characterAttributeCustomisationList;

    private float movementSpeed;

    [Tooltip("Should be populated in the prefab with the equipped item sprite renderer")]
    [SerializeField] private SpriteRenderer equippedItemSpriteRenderer = null;

    //Player Can Swapped
    private CharacterAttribute armsCharacterAttribute;
    private CharacterAttribute toolCharacterAttribute;

    private bool _playerInputIsDisabled = false;

    public bool PlayerInputIsDisabled {get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }

    protected override void Awake()
    {
        base.Awake();
        
        rigidBody = GetComponent<Rigidbody>();

        animationOverrides = GetComponent<AnimationOverrides>();
        armsCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.body, PartVariantColour.none, PartVariantType.none);
        toolCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.body, PartVariantColour.none, PartVariantType.hoe);

        characterAttributeCustomisationList = new List<CharacterAttribute>();

        mainCamera = Camera.main; //26//
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadFadeOutEvent -= DisablePlayerInputAndResetMovement;
        EventHandler.AfterSceneLoadFadeInEvent -= EnablePlayerInput;
    }

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadFadeOutEvent += DisablePlayerInputAndResetMovement;
        EventHandler.AfterSceneLoadFadeInEvent += EnablePlayerInput;
    }

    void getNewPosition(Vector3 newposition)
    {
        MPosition = newposition;
    }

    private void Start()
    {
        gridCursor = FindObjectOfType<GridCursor>();
        cursor = FindObjectOfType<Cursor>();
        useToolAnimationPause = new WaitForSeconds(Settings.useToolAnimationPause);
        liftToolAnimationPause = new WaitForSeconds(Settings.liftToolAnimationPause);
        pickAnimationPause = new WaitForSeconds(Settings.pickAnimationPause);
        afterUseToolAnimationPause = new WaitForSeconds(Settings.afterUseToolAnimationPause);
        afterLiftToolAnimationPause =  new WaitForSeconds(Settings.afterLiftToolAnimationPause);
        afterPickAnimationPause = new WaitForSeconds(Settings.afterPickAnimationPause);
    }

    private void Update()
    {
        #region Player Input

        if (!PlayerInputIsDisabled)
        {
            ResetAnimationTriggers();

            PlayerMovementInput();

            //PlayerWalkInput();
            // PlayerDigInput();

            PlayerClickInput();

            PlayerTestInput();

            PlayerGetStatus();

            PlayerRespawn();

            EventHandler.CallMovementEvent(vInput, hInput, isWalking, isIdle, isCarrying,
                                            toolEffect,
                                            isUsingMiningToolUp, isUsingMiningToolDown, isUsingMiningToolLeft, isUsingMiningToolRight,
                                            isUsingChoppingToolUp, isUsingChoppingToolDown, isUsingChoppingToolLeft, isUsingChoppingToolRight,
                                            isUsingDiggingToolUp, isUsingDiggingToolDown, isUsingDiggingToolLeft, isUsingDiggingToolRight,
                                            isUsingLiftingToolUp, isUsingLiftingToolDown, isUsingLiftingToolLeft, isUsingLiftingToolRight,
                                            isUsingSwingingToolUp, isUsingSwingingToolDown, isUsingSwingingToolLeft, isUsingSwingingToolRight,
                                            false,false,false,false);
        }
    
        #endregion Player Input
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
        isUsingMiningToolUp = false;
        isUsingMiningToolDown = false;
        isUsingMiningToolLeft = false;
        isUsingMiningToolRight = false;
        isUsingChoppingToolUp = false;
        isUsingChoppingToolDown = false;
        isUsingChoppingToolLeft = false;
        isUsingChoppingToolRight = false;
        isUsingDiggingToolUp = false;
        isUsingDiggingToolDown = false;
        isUsingDiggingToolLeft = false;
        isUsingDiggingToolRight = false;
        isUsingLiftingToolUp = false;
        isUsingLiftingToolDown = false;
        isUsingLiftingToolLeft = false;
        isUsingLiftingToolRight = false;
        isUsingSwingingToolUp = false;
        isUsingSwingingToolDown = false;
        isUsingSwingingToolLeft = false;
        isUsingSwingingToolRight = false;
        toolEffect = ToolEffect.none;
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
            
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if(PlayerExhausted == false)            //      ถ้าไม่เหนื่อยเข้า loop   (ถ้ามีstaminaจะไม่ทำ) //
                {
                    movementSpeed = Settings.runningSpeed;
                }
                else
                {
                    movementSpeed = Settings.walkingSpeed;
                }
            }
            else
            {
                movementSpeed = Settings.walkingSpeed;
            }
           

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
        {   Debug.Log("Run");
            //isRunning = false;
            // isWalking = false;
            // isIdle = false;
            // movementSpeed = Settings.walkingSpeed;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
        else
        {   Debug.Log("Walk");
            //isRunning = true;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
    }

    private void PlayerClickInput()
    {
        if(!playerToolUseDisabled)
        {
            if (Input.GetMouseButton(0))
            {
                if (gridCursor.CursorIsEnabled)
                {
                     Vector3Int cursorGridPosition = gridCursor.GetGridPositionForCursor();
                    Vector3Int playerGridPosition = gridCursor.GetGridPositionForPlayer();
                
                    ProcessPlayerClickInput(cursorGridPosition, playerGridPosition);
                }
            }
        }   
    }

    private void ProcessPlayerClickInput(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        ResetMovement();

        Vector3Int playerDirection = GetPlayerClickDirection(cursorGridPosition, playerGridPosition);

        GridPropertyDetails gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cursorGridPosition.x, cursorGridPosition.y);

        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedInventoryItemDetails(InventoryLocation.player);

        if (itemDetails != null)
        {
            switch (itemDetails.itemType)
            {
                case ItemType.Seed :
                    if (Input.GetMouseButtonDown(0))
                    {
                        ProcessPlayerClickInputSeed(gridPropertyDetails, itemDetails);
                    }
                    break;

                case ItemType.Commodity :
                    if (Input.GetMouseButtonDown(0))
                    {
                        ProcessPlayerClickInputCommodity(itemDetails);
                    }
                    break;

                case ItemType.Watering_tool :
                case ItemType.Chopping_tool :
                case ItemType.Hoeing_tool :
                case ItemType.Collecting_tool :
                    if(PlayerExhausted == false)            //      ถ้าไม่เหนื่อยเข้า loop   (ถ้ามีstaminaจะไม่ทำ) //
                        {
                            ProcessPlayerClickInputTool(gridPropertyDetails, itemDetails, playerDirection);  
                        }
                    break;
                
                case ItemType.none :
                    break;
                
                case ItemType.count :
                    break;
                
                default :
                    break;
            }
        }
    }

    private Vector3Int GetPlayerClickDirection(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        if(cursorGridPosition.x > playerGridPosition.x)
        {
            return Vector3Int.right;
        }
        else if (cursorGridPosition.x < playerGridPosition.x)
        {
            return Vector3Int.left;
        }
        else if (cursorGridPosition.y > playerGridPosition.y)
        {
            return Vector3Int.up;
        }
        else
        {
            return Vector3Int.down;
        }
    }

    private void ProcessPlayerClickInputSeed(GridPropertyDetails gridPropertyDetails,ItemDetails itemDetails)
    {
        if(itemDetails.canBeDropped && gridCursor.CursorPositionIsValid && gridPropertyDetails.daysSinceDug > -1 && gridPropertyDetails.seedItemCode == -1)
        {
            PlantSeedAtCursor(gridPropertyDetails, itemDetails);
        }
        else if (itemDetails.canBeDropped && gridCursor.CursorPositionIsValid)
        {
            EventHandler.CallDropSelectedItemEvent();
        }
    }

    private void PlantSeedAtCursor (GridPropertyDetails gridPropertyDetails, ItemDetails itemDetails)
    {
        //Update grid properties with seed details
        gridPropertyDetails.seedItemCode = itemDetails.itemCode;
        gridPropertyDetails.growthDays = 0;

        //Display planted crop at grid Property details
        GridPropertiesManager.Instance.DisplayPlantedCrop(gridPropertyDetails);

        //Remove item from inventory
        EventHandler.CallRemoveSelectedItemFromInventoryEvent();
    }

    private void ProcessPlayerClickInputCommodity(ItemDetails itemDetails)
    {
        if (itemDetails.canBeDropped && gridCursor.CursorPositionIsValid)
        {
            EventHandler.CallDropSelectedItemEvent();
        }
    }

    private void ProcessPlayerClickInputTool(GridPropertyDetails gridPropertyDetails, ItemDetails itemDetails, Vector3Int playerDirection)
    {
        switch (itemDetails.itemType)
        {
            case ItemType.Hoeing_tool :
                if (gridCursor.CursorPositionIsValid)
                {
                    HoeGroundAtCursor(gridPropertyDetails, playerDirection);
                }
                break;
            
            case ItemType.Watering_tool :
                if(gridCursor.CursorPositionIsValid)
                {
                    WaterGroundAtCursor(gridPropertyDetails, playerDirection);
                }
                break;

            case ItemType.Chopping_tool :
                if(gridCursor.CursorPositionIsValid)
                {
                    ChopInPlayerDirection(gridPropertyDetails, itemDetails, playerDirection);
                }
                break;
            
            case ItemType.Collecting_tool :
                if(gridCursor.CursorPositionIsValid)
                {
                    CollectInPlayerDirection(gridPropertyDetails, itemDetails, playerDirection);
                }
                break;

            default :
                break;
        }
    }

    private void HoeGroundAtCursor(GridPropertyDetails gridPropertyDetails, Vector3Int playerDirection)
    {
        StartCoroutine(HoeGroundAtCursorRoutine(playerDirection, gridPropertyDetails));
    }

    private IEnumerator HoeGroundAtCursorRoutine(Vector3Int playerDirection, GridPropertyDetails gridPropertyDetails)
    {
        PlayerInputIsDisabled = true;
        playerToolUseDisabled = true;
        
        // toolCharacterAttribute.partVariantType = PartVariantType.hoe;
        // characterAttributeCustomisationList.Clear();
        // characterAttributeCustomisationList.Add(toolCharacterAttribute);
        // animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);            

        if(playerDirection == Vector3Int.right)
        {
            StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseDiggingToolRight());
        }
        if(playerDirection == Vector3Int.left)
        {
            StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseDiggingToolLeft());
        }
        if(playerDirection == Vector3Int.up)
        {
            StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseDiggingToolUp());
        }
        if(playerDirection == Vector3Int.down)
        {
            StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseDiggingToolDown());
            //isUsingChoppingToolDown = true;
        }
        yield return useToolAnimationPause;

        if (gridPropertyDetails.daysSinceDug == -1)
        {
            gridPropertyDetails.daysSinceDug = 0;
        }

        GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);

        // Display dug grid tiles
        GridPropertiesManager.Instance.DisplayDugGround(gridPropertyDetails);

        yield return afterUseToolAnimationPause;

        PlayerStatus.Instance.GetTired(10);
        PlayerInputIsDisabled = false;
        playerToolUseDisabled = false;
    }

    private void WaterGroundAtCursor(GridPropertyDetails gridPropertyDetails, Vector3Int playerDirection)
    {
        StartCoroutine(WaterGroundAtCursorRoutine(playerDirection, gridPropertyDetails));
    }

    private IEnumerator WaterGroundAtCursorRoutine (Vector3Int playerDirection, GridPropertyDetails gridPropertyDetails)
    {
            PlayerInputIsDisabled = true;
            playerToolUseDisabled = true;

            // toolCharacterAttribute.partVariantType = PartVariantType.wateringCan;
            // characterAttributeCustomisationList.Clear();
            // characterAttributeCustomisationList.Add(toolCharacterAttribute);
            // animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

            toolEffect = ToolEffect.watering;

            if(playerDirection == Vector3Int.right)
            {
                StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseLiftingToolRight());
            }
            if(playerDirection == Vector3Int.left)
            {
                StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseLiftingToolLeft());
            }
            if(playerDirection == Vector3Int.up)
            {
                StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseLiftingToolUp());
            }
            if(playerDirection == Vector3Int.down)
            {
                StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseLiftingToolDown());
            }
            yield return liftToolAnimationPause;

            if (gridPropertyDetails.daysSinceWatered == -1)
            {
                gridPropertyDetails.daysSinceWatered = 0;
            }

            GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);

            GridPropertiesManager.Instance.DisplayWateredGround(gridPropertyDetails);

            yield return afterLiftToolAnimationPause;

            PlayerInputIsDisabled = false;
            playerToolUseDisabled = false;

    }

    private void ChopInPlayerDirection(GridPropertyDetails gridPropertyDetails, ItemDetails equippedItemDetails, Vector3Int playerDirection)
    {
        //Trigger animation
        StartCoroutine(ChopInPlayerDirectionRoutine(gridPropertyDetails, equippedItemDetails, playerDirection));
    }

    private IEnumerator ChopInPlayerDirectionRoutine(GridPropertyDetails gridPropertyDetails, ItemDetails equippedItemDetails, Vector3Int playerDirection)
    {
        PlayerInputIsDisabled = true;
        playerToolUseDisabled = true;

        // //Set tool aniamtion to axe in override animation
        // toolCharacterAttribute.partVariantType = PartVariantType.axe;
        // characterAttributeCustomisationList.Clear();
        // characterAttributeCustomisationList.Add(toolCharacterAttribute);
        // animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        ProcessCropWithEquippedItemInPlayerDirection(playerDirection, equippedItemDetails, gridPropertyDetails);
        

        yield return useToolAnimationPause;

        //After animation pause
        yield return afterUseToolAnimationPause;

        PlayerInputIsDisabled = false;
        playerToolUseDisabled = false;
    }

    private void CollectInPlayerDirection(GridPropertyDetails gridPropertyDetails, ItemDetails equippedItemDetails, Vector3Int playerDirection)
    {
        StartCoroutine(CollectInPlayerDirectionRoutine(gridPropertyDetails, equippedItemDetails, playerDirection));
    }

    private IEnumerator CollectInPlayerDirectionRoutine(GridPropertyDetails gridPropertyDetails, ItemDetails equippedItemDetails, Vector3Int playerDirection)
    {
        PlayerInputIsDisabled = true;
        playerToolUseDisabled = true;


        ProcessCropWithEquippedItemInPlayerDirection(playerDirection, equippedItemDetails, gridPropertyDetails);

        //yield return pickAnimationPause;

        //After animationPause
        yield return afterPickAnimationPause;

        PlayerInputIsDisabled = false;
        playerToolUseDisabled = false;
    }

    private void ProcessCropWithEquippedItemInPlayerDirection(Vector3Int playerDirection, ItemDetails equippedItemDetails, GridPropertyDetails gridPropertyDetails)
    {
        switch (equippedItemDetails.itemType)
        {
            case ItemType.Chopping_tool:
            if(playerDirection == Vector3Int.right)
                 {
                     StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseChoppingToolRight());
                 }
                 else if (playerDirection == Vector3Int.left)
                 {
                     StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseChoppingToolLeft());
                 }
                 else if (playerDirection == Vector3Int.up)
                 {
                     StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseChoppingToolUp());
                 }
                 else if (playerDirection == Vector3Int.down)
                 {
                     StartCoroutine(GetAnimator.GetComponent<AnimatorController>().UseChoppingToolDown());
                 }
                 break;

            // case ItemType.Collecting_tool :
                 
            //      if(playerDirection == Vector3Int.right)
            //      {
            //          isPickingRight = true;
            //      }
            //      else if (playerDirection == Vector3Int.left)
            //      {
            //          isPickingLeft = true;
            //      }
            //      else if (playerDirection == Vector3Int.up)
            //      {
            //          isPickingUp = true;
            //      }
            //      else if (playerDirection == Vector3Int.down)
            //      {
            //          isPickingDown = true;
            //      }
            //      break;

            case ItemType.none :
                break;
        }

        //Get crops at cursor grid location
        Crop crop = GridPropertiesManager.Instance.GetCropObjectAtGridLocation(gridPropertyDetails);
        
        //Execute Process Tool Action For crop
        if (crop != null)
        {
            switch (equippedItemDetails.itemType)
            {
                case ItemType.Chopping_tool : 
                    crop.ProcessToolAction(equippedItemDetails);
                    break;

                case ItemType.Collecting_tool :
                    crop.ProcessToolAction(equippedItemDetails);
                    break;
            }
        }
    }

    private void PlayerTestInput()                  //35//
    {
        if (Input.GetKey(KeyCode.T))
        {
            TimeManager.Instance.TestAdvanceGameMinute();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TimeManager.Instance.TestAdvanceGameDay();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TimeManager.Instance.TestAdvanceSkip();
        }


        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     SceneControllerManager.Instance.FadeAndLoadScene(SceneName.Scene1_Farm.ToString(), transform.position);
        // }
    }

    private void ResetMovement()
    {
        hInput = 0f;
        vInput = 0f;
        isWalking = false;
        isIdle = true;

    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();

        EventHandler.CallMovementEvent(vInput, hInput, isWalking, isIdle, isCarrying,
                                        toolEffect,
                                        isUsingMiningToolUp, isUsingMiningToolDown, isUsingMiningToolLeft, isUsingMiningToolRight,
                                        isUsingChoppingToolUp, isUsingChoppingToolDown, isUsingChoppingToolLeft, isUsingChoppingToolRight,
                                        isUsingDiggingToolUp, isUsingDiggingToolDown, isUsingDiggingToolLeft, isUsingDiggingToolRight,
                                        isUsingLiftingToolUp, isUsingLiftingToolDown, isUsingLiftingToolLeft, isUsingLiftingToolRight,
                                        isUsingSwingingToolUp, isUsingSwingingToolDown, isUsingSwingingToolLeft, isUsingSwingingToolRight,
                                        false,false,false,false);
        
    }
    
    public void DisablePlayerInput()
    {
        PlayerInputIsDisabled = true ;
    }

    public void EnablePlayerInput()
    {
        PlayerInputIsDisabled = false;
    }

    public Vector3 GetPlayerViewporPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }

    public Vector3 GetPlayerCentrePosition()
    {
        return new Vector3(transform.position.x, transform.position.y + Settings.playerCentreYOffset, transform.position.z);
    }

    public void DoSleep()
    {
        StartCoroutine(SleepRoutine());
    }

    IEnumerator SleepRoutine()
    {
        ScreenTint screenTint = GameManager.instance.screenTint;

        screenTint.Tint();
        yield return new WaitForSeconds(1f);
        TimeManager.Instance.TestAdvanceSkip();

        screenTint.UnTint();
        yield return new WaitForSeconds(1f);

        UIManager.Instance.DisableFadeBlack();

        yield return null;
    }

    private void PlayerGetStatus()
    {
        PlayerDead = PlayerStatus.Instance.isDead;
        PlayerExhausted = PlayerStatus.Instance.isExhausted;
    }

    private void PlayerRespawn()
    {
        if(PlayerDead == true)
        {
            PlayerStatus.Instance.isDead = false; 
            UIManager.Instance.EnableFadeBlack();
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        ScreenTint screenTint = GameManager.instance.screenTint;

        screenTint.Tint();
        yield return new WaitForSeconds(2f);

        PlayerObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);            //Move to Target
        Debug.Log("Die");
        PlayerStatus.Instance.Heal(5);
        yield return new WaitForSeconds(1f);

        screenTint.UnTint();
        yield return new WaitForSeconds(1f);

        UIManager.Instance.DisableFadeBlack();

        yield return null;
    }
    
}
