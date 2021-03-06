using System;
using System.Collections.Generic;

public delegate void MovementDelegate(float inputV, float inputH, bool isWalking, bool isIdle, bool isCarrying,
                                        ToolEffect toolEffect,
                                        bool isUsingMiningToolUp, bool isUsingMiningToolDown, bool isUsingMiningToolLeft, bool isUsingMiningToolRight,
                                        bool isUsingChoppingToolUp, bool isUsingChoppingToolDown, bool isUsingChoppingToolLeft, bool isUsingChoppingToolRight,
                                        bool isUsingDiggingToolUp, bool isUsingDiggingToolDown, bool isUsingDiggingToolLeft, bool isUsingDiggingToolRight,
                                        bool isUsingLiftingToolUp, bool isUsingLiftingToolDown, bool isUsingLiftingToolLeft, bool isUsingLiftingToolRight,
                                        bool isUsingSwingingToolUp, bool isUsingSwingingToolDown, bool isUsingSwingingToolLeft, bool isUsingSwingingToolRight,
                                        bool idleUp, bool idleDown, bool idleRight, bool idleLeft);

                                        
public static class EventHandler
{
    //Drop Selected item event
    public static event Action DropSelectedItemEvent;

    public static void CallDropSelectedItemEvent()
    {
        if(DropSelectedItemEvent != null)
        DropSelectedItemEvent();
    }

    //Remove Selected item from inventory
    public static event Action RemoveSelectedItemFromInventoryEvent;

    public static void CallRemoveSelectedItemFromInventoryEvent()
    {
        if(RemoveSelectedItemFromInventoryEvent != null)
        RemoveSelectedItemFromInventoryEvent();
    }

    //Inventory Update Event
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem>inventoryList)
    {
        if (InventoryUpdatedEvent != null)
            InventoryUpdatedEvent(inventoryLocation, inventoryList);
    }

    //Instantiate crop prefab
    public static event Action InstantiateCropPrefabsEvent;

    public static void CallInstantiateCropPrefabsEvent()
    {
        if (InstantiateCropPrefabsEvent != null)
        {
            InstantiateCropPrefabsEvent();
        }
    }

    //Movement Event
    public static event MovementDelegate MovementEvent;

    //Movement Event Call For Publishers
    public static void CallMovementEvent(float inputV, float inputH, bool isWalking, bool isIdle, bool isCarrying,
                                        ToolEffect toolEffect,
                                        bool isUsingMiningToolUp, bool isUsingMiningToolDown, bool isUsingMiningToolLeft, bool isUsingMiningToolRight,
                                        bool isUsingChoppingToolUp, bool isUsingChoppingToolDown, bool isUsingChoppingToolLeft, bool isUsingChoppingToolRight,
                                        bool isUsingDiggingToolUp, bool isUsingDiggingToolDown, bool isUsingDiggingToolLeft, bool isUsingDiggingToolRight,
                                        bool isUsingLiftingToolUp, bool isUsingLiftingToolDown, bool isUsingLiftingToolLeft, bool isUsingLiftingToolRight,
                                        bool isUsingSwingingToolUp, bool isUsingSwingingToolDown, bool isUsingSwingingToolLeft, bool isUsingSwingingToolRight,
                                        bool idleUp, bool idleDown, bool idleRight, bool idleLeft)
    {
        if (MovementEvent != null)
            MovementEvent(inputV, inputH, isWalking, isIdle, isCarrying,
                            toolEffect,
                            isUsingMiningToolUp, isUsingMiningToolDown, isUsingMiningToolLeft, isUsingMiningToolRight,
                            isUsingChoppingToolUp, isUsingChoppingToolDown, isUsingChoppingToolLeft, isUsingChoppingToolRight,
                            isUsingDiggingToolUp, isUsingDiggingToolDown, isUsingDiggingToolLeft, isUsingDiggingToolRight,
                            isUsingLiftingToolUp, isUsingLiftingToolDown, isUsingLiftingToolLeft, isUsingLiftingToolRight,
                            isUsingSwingingToolUp, isUsingSwingingToolDown, isUsingSwingingToolLeft, isUsingSwingingToolRight,
                            idleUp, idleDown, idleRight, idleLeft);
    }

                            //Time Event//
                            //Advance game Minute//
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameMinuteEvent;
                      
    public static void CallAdvanceGameMinuteEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameMinuteEvent != null)
        {
            AdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

                            //Advance game Hour//
     public static event Action<int, Season, int, string, int, int, int> AdvanceGameHourEvent;
     public static void CallAdvanceGameHourEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameHourEvent != null)
        {
            AdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

                            //Advance game Day//
     public static event Action<int, Season, int, string, int, int, int> AdvanceGameDayEvent;
     public static void CallAdvanceGameDayEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameDayEvent != null)
        {
            AdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

                            //Advance game Season//
     public static event Action<int, Season, int, string, int, int, int> AdvanceGameSeasonEvent;
     public static void CallAdvanceGameSeasonEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameSeasonEvent != null)
        {
            AdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

                            //Advance game Year//
     public static event Action<int, Season, int, string, int, int, int> AdvanceGameYearEvent;
     public static void CallAdvanceGameYearEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameYearEvent != null)
        {
            AdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    //Scene Load Event

    //Before Scene Unload Fade Out Event
    public static event Action BeforeSceneUnloadFadeOutEvent;

    public static void CallBeforeSceneUnloadFadeOutEvent()
    {
        if (BeforeSceneUnloadFadeOutEvent != null)
        {
            BeforeSceneUnloadFadeOutEvent();
        }
    }

    //Before Scene Unload Event
    public static event Action BeforeSceneUnloadEvent;

    public static void CallBeforeSceneUnloadEvent()
    {
        if(BeforeSceneUnloadEvent != null)
        {
            BeforeSceneUnloadEvent();
        }
    }

    //After Scene Loaded Event
    public static event Action AfterSceneLoadEvent;

    public static void CallAfterSceneLoadEvent()
    {
        if(AfterSceneLoadEvent != null)
        {
            AfterSceneLoadEvent();
        }
    }

    //After Scene Loaded Fade In Event
    public static event Action AfterSceneLoadFadeInEvent;

    public static void CallAfterSceneLoadFadeInEvent()
    {
        if (AfterSceneLoadFadeInEvent != null)
        {
            AfterSceneLoadFadeInEvent();
        }
    }
}