using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public DialogueSystem dialogueSystem;
    public ShopManagerScript ShopManagerScript;
    public GetPlayerPosition getPlayerPosition;
    public TimeManager timeManager;
    public ScreenTint screenTint;
}
