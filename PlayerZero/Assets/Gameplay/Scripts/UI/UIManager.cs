using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonobehaviour<UIManager>
{
    private bool _pauseMenuOn = false;
    private bool _shopMenuOn = false;
    private bool _canSleepMenuOn = false;
    private bool _notSleepMenuOn = false;
    private bool _fadeBlack = false;
    private bool _dialogBoxOn = false;
    private bool _summaryOn = false;
    private bool _debugScreenOn = false;
    [SerializeField] private UIInventoryBar uiInventoryBar = null;
    [SerializeField] private PauseMenuInventoryManagement pauseMenuInventoryManagement = null;
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject shopMenu = null;
    [SerializeField] private GameObject dialogBox = null;
    [SerializeField] private GameObject summary = null;
    [SerializeField] private GameObject canSleepMenu = null;
    [SerializeField] private GameObject notSleepMenu = null;
    [SerializeField] private GameObject fadeBlack = null;
    [SerializeField] private GameObject debugScreen = null;
    [SerializeField] private GameObject[] menuTabs = null;
    [SerializeField] private Button[] menuButtons = null;

    public bool PauseMenuOn { get => _pauseMenuOn; set => _pauseMenuOn = value; }
    public bool ShopMenuOn { get => _shopMenuOn; set => _shopMenuOn = value; }
    public bool CanSleepMenuOn { get => _canSleepMenuOn; set => _canSleepMenuOn = value; }
    public bool NotSleepMenuOn { get => _notSleepMenuOn; set => _notSleepMenuOn = value; }
    public bool FadeBlack { get => _fadeBlack; set => _fadeBlack = value; }
    public bool DialogBoxOn { get => _dialogBoxOn; set => _dialogBoxOn = value; }
    public bool SummaryOn { get => _summaryOn; set => _summaryOn = value; }
    public bool DebugScreenOn { get => _debugScreenOn; set => _debugScreenOn = value; }

    protected override void Awake()
    {
        base.Awake();

        pauseMenu.SetActive(false);
        shopMenu.SetActive(false);
        canSleepMenu.SetActive(false);
        notSleepMenu.SetActive(false);
        fadeBlack.SetActive(false);
        dialogBox.SetActive(false);
        summary.SetActive(false);
        debugScreen.SetActive(false);
    }

    //Update is Called once per frame
    private void Update()
    {
        bool ShopStatus =  GameManager.instance.dialogueSystem.ShopEnter;
        // Debug.Log("ShopStatus = " + ShopStatus);
        PauseMenu();
        DebugScreen();
        //ShopMenu(ShopStatus);

        if(PauseMenuOn || ShopMenuOn || CanSleepMenuOn || NotSleepMenuOn || DialogBoxOn || SummaryOn == true)
        {
            Player.Instance.canShootCrossbow = false;       //Set Crossbow
        }
    }

    private void PauseMenu()
    {
        //Toggle pause menu if escape is pressed

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuOn)
            {
                DisablePauseMenu();
            }
            else
            {
                EnablePauseMenu();
            }
        }
    }

    private void EnablePauseMenu()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        PauseMenuOn = true;
        Player.Instance.PlayerInputIsDisabled = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

        //Trigger garbage collector
        System.GC.Collect();

        //Highlight selected button
        HighlightButtonForSelectedTab();
    }

    public void DisablePauseMenu()
    {
        //Destroy any currently dragged items
        pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        PauseMenuOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow
    }

    public void ShopMenu(bool ShopStatus)
    {
        //Toggle pause menu if escape is pressed

        // if (Input.GetKeyDown(KeyCode.B) && ShopStatus == true)
        // {
            if (ShopMenuOn)
            {
                DisableShopMenu();

                DialogueSystem.Instance.Conclude();
            }
            else
            {
                EnableShopMenu();
            }
        //}
    }

    private void EnableShopMenu()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        ShopMenuOn = true;
        Player.Instance.PlayerInputIsDisabled = true;
        Time.timeScale = 0;
        shopMenu.SetActive(true);

        // //Trigger garbage collector
        // System.GC.Collect();

        // //Highlight selected button
        // HighlightButtonForSelectedTab();
    }

    private void DisableShopMenu()
    {
        // //Destroy any currently dragged items
        // pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        ShopMenuOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        shopMenu.SetActive(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow
    }

    public void EnableCanSleepMenu()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        CanSleepMenuOn = true;
        Player.Instance.PlayerInputIsDisabled = true;
        Time.timeScale = 0;
        canSleepMenu.SetActive(true);

        // //Trigger garbage collector
        // System.GC.Collect();

        // //Highlight selected button
        // HighlightButtonForSelectedTab();
    }

    public void DisableCanSleepMenu()
    {
        // //Destroy any currently dragged items
        // pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        CanSleepMenuOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        canSleepMenu.SetActive(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow

    }

    public void EnableNotSleepMenu()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        NotSleepMenuOn = true;
        Player.Instance.PlayerInputIsDisabled = true;
        Time.timeScale = 0;
        notSleepMenu.SetActive(true);

        // //Trigger garbage collector
        // System.GC.Collect();

        // //Highlight selected button
        // HighlightButtonForSelectedTab();
    }

    public void DisableNotSleepMenu()
    {
        // //Destroy any currently dragged items
        // pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        NotSleepMenuOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        notSleepMenu.SetActive(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow
    }

    public void EnableFadeBlack()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        FadeBlack = true;
        fadeBlack.SetActive(true);
    }

    public void DisableFadeBlack()
    {
        FadeBlack = false;
        fadeBlack.SetActive(false);
    }

    public void EnableDialogBox()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        DialogBoxOn = true;
        Player.Instance.PlayerInputIsDisabled = true;
        Time.timeScale = 0;
        dialogBox.SetActive(true);

        //Trigger garbage collector
        System.GC.Collect();

        //Highlight selected button
        HighlightButtonForSelectedTab();
    }

    public void DisableDialogBox()
    {
        //Destroy any currently dragged items
        //pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        DialogBoxOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        dialogBox.SetActive(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow
    }

    public void EnableSummary()
    {
        //Destroy any currently dragged items
        uiInventoryBar.DestroyCurrentlyDraggedItems();

        //Clear currently selected items
        uiInventoryBar.ClearCurrentlySelectedItems();

        SummaryOn = true;
        Player.Instance.PlayerInputIsDisabled = true;
        Time.timeScale = 0;
        summary.SetActive(true);

        // //Trigger garbage collector
        // System.GC.Collect();

        // //Highlight selected button
        // HighlightButtonForSelectedTab();
    }

    public void DisableSummary()
    {
        // //Destroy any currently dragged items
        // pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        SummaryOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        summary.SetActive(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow
    }

    private void DebugScreen()
    {
        //Toggle pause menu if escape is pressed

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (DebugScreenOn)
            {
                DebugScreenOn = false;
                debugScreen.SetActive(false);
            }
            else
            {
                DebugScreenOn = true;
                debugScreen.SetActive(true);
            }
        }
    }



    private void HighlightButtonForSelectedTab()
    {
        for (int i = 0; i < menuTabs.Length; i++)
        {
            if (menuTabs[i].activeSelf)
            {
                SetButtonColorToActive(menuButtons[i]);
            }

            else
            {
                SetButtonColorToInactive(menuButtons[i]);
            }
        }
    }

    private void SetButtonColorToActive(Button button)
    {
        ColorBlock colors = button.colors;

        colors.normalColor = colors.pressedColor;

        button.colors = colors;
    }

    private void SetButtonColorToInactive(Button button)
    {
        ColorBlock colors = button.colors;

        colors.normalColor = colors.disabledColor;

        button.colors = colors;
    }

    public void SwitchPauseMenuTab(int tabNum)
    {
        for (int i = 0; i < menuTabs.Length; i++)
        {
            if(i != tabNum)
            {
                menuTabs[i].SetActive(false);
            }
            else
            {
                menuTabs[i].SetActive(true);
            }
        }
        HighlightButtonForSelectedTab();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CraftArrow()
    {
        if(InventoryManager.Instance.haveWood)
        {
            InventoryManager.Instance.RemoveItem(InventoryLocation.player, 10014);

            for(int i = 0; i < 3; i++)
            {
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10018);
            }
        }
    }
}
