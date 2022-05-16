using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    public static GameManager instance;

    protected override void Awake()
    {
        instance = this;

        base.Awake();

        Screen.SetResolution(1980, 1080, FullScreenMode.FullScreenWindow, 0);
    }
    
    public DialogueSystem dialogueSystem;
    public ShopManagerScript ShopManagerScript;
    public GetPlayerPosition getPlayerPosition;
    public TimeManager timeManager;
    public ScreenTint screenTint;
    public SaveLoadManager saveLoadManager;
}
