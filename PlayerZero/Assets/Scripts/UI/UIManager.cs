using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonobehaviour<UIManager>
{
    private bool _pauseMenuOn = false;
    private bool _shopMenuOn = false;
    [SerializeField] private UIInventoryBar uiInventoryBar = null;
    [SerializeField] private PauseMenuInventoryManagement pauseMenuInventoryManagement = null;
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject shopMenu = null;
    [SerializeField] private GameObject[] menuTabs = null;
    [SerializeField] private Button[] menuButtons = null;

    public bool PauseMenuOn { get => _pauseMenuOn; set => _pauseMenuOn = value; }
    public bool ShopMenuOn { get => _shopMenuOn; set => _shopMenuOn = value; }

    protected override void Awake()
    {
        base.Awake();

        pauseMenu.SetActive(false);
        shopMenu.SetActive(false);
    }

    //Update is Called once per frame
    private void Update()
    {
        bool ShopStatus =  GameManager.instance.dialogueSystem.ShopEnter;
        // Debug.Log("ShopStatus = " + ShopStatus);
        PauseMenu();
        ShopMenu(ShopStatus);
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

    private void DisablePauseMenu()
    {
        //Destroy any currently dragged items
        pauseMenuInventoryManagement.DestroyCurrentlyDraggedItems();

        PauseMenuOn = false;
        Player.Instance.PlayerInputIsDisabled = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    private void ShopMenu(bool ShopStatus)
    {
        //Toggle pause menu if escape is pressed

        if (Input.GetKeyDown(KeyCode.B) && ShopStatus == true)
        {
            if (ShopMenuOn)
            {
                DisableShopMenu();
            }
            else
            {
                EnableShopMenu();
            }
        }
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
}
