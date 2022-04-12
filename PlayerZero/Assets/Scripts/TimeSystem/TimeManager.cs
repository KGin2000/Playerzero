using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonobehaviour<TimeManager>
{
    private int gameYear = 1;
    private Season gameSeason = Season.Spring;
    private int gameDay = 1;
    public int gameHour = 6;
    private int gameMinute = 0;
    private int gameSecond = 0;
    private float lightRotate = 0.0f;
    private string gameDayOfWeek = "Mon";

    private bool gameClockPaused = false;

    private float gameTick = 0f;
    float x = 0;

    private void Start()
    {
        EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
    }

    private void Update()
    {
        if (!gameClockPaused)
        {
            GameTick();
        }
        // SendRotateLight();
    }

    private void GameTick()
    {
        gameTick += Time.deltaTime;

        if (gameTick >= Settings.secondsPerGameSecond)
        {
            gameTick -= Settings.secondsPerGameSecond;

            UpdateGameSecond();
            UpdateLightRotate();
        }
        
    }

    private void UpdateGameSecond()
    {
        gameSecond++;
        //Debug.Log("gameSecond = " + gameSecond);

        if (gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;

            if (gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;

                if (gameHour > 23)
                {
                    gameHour = 0;
                    gameDay++;

                    if (gameDay > 30)
                    {
                        gameDay = 1;

                        int gs = (int)gameSeason;
                        gs++;

                        gameSeason = (Season)gs;

                        if (gs > 3)
                        {
                            gs = 0;
                            gameSeason = (Season)gs;

                            gameYear++;

                            if (gameYear > 9999)
                                gameYear = 1;

                            EventHandler.CallAdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                        }

                        EventHandler.CallAdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                    }

                    gameDayOfWeek = GetDayOfWeek();
                    EventHandler.CallAdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                }

                EventHandler.CallAdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
            }

            EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);

            //Debug.Log("Game Year : " + gameYear + " Game Season : " + gameSeason + " Game Day : " + gameDay + " Game Hour : " + gameHour + " Game Minute : " + gameMinute);
        }
        
        // Call
    }

    private void UpdateLightRotate()
    {
        if(gameHour >= 18)
        {
            RotateLight.Instance.RotateLightingDown(0.02f);
        }
        if(gameHour == 0)
        {
            RotateLight.Instance.ReSetLight();
        }
        if(gameHour >= 5)
        {
            if(gameHour < 7)
            {
                RotateLight.Instance.RotateLightingUp(0.02f);
            }
        }
    }
    
    private string GetDayOfWeek()
    {
        int totalDays = (((int)gameSeason) * 30) + gameDay;
        int dayOfWeek = totalDays % 7;

        switch (dayOfWeek)
        {
            case 1 :
                return "Mon";
            
            case 2 :
                return "Tue";

            case 3 :
                return "Wed";

            case 4 :
                return "Thu";

            case 5 :
                return "Fri";

            case 6 :
                return "Sat";

            case 0 : 
                return "Sun";

            default :
                return "";
        }
    }

    public void TestAdvanceGameMinute()
    {
        for (int i = 0; i < 60; i++)
        {
            UpdateGameSecond();
            UpdateLightRotate();
        }
    }

    public void TestAdvanceGameDay()
    {
        for (int i = 0; i < 86400; i++)
        {
            UpdateGameSecond();
            UpdateLightRotate();
        }
    }

    public void TestAdvanceSkip()
    {
        if (gameHour >= 20 && gameHour <= 23)
        {
            // Debug.Log("IF");
            int gamHourCal = ((24 - gameHour) + 6) * 3600 ;
            for (int i = 0; i < gamHourCal; i++)
            {
                UpdateGameSecond();
                UpdateLightRotate();
            }

            PlayerStatus.Instance.isExhausted = false;
            PlayerStatus.Instance.FullRest();

            gameMinute = 0;
            gameHour = 6;
        }

        if (gameHour >= 0 && gameHour <= 5)
        {
            // Debug.Log("IF");
            int gamHourCal = (6 - gameHour) * 3600 ;
            for (int i = 0; i < gamHourCal; i++)
            {
                UpdateGameSecond();
                UpdateLightRotate();
            }

            PlayerStatus.Instance.isExhausted = false;
            PlayerStatus.Instance.HalfRest();

            gameMinute = 0;
            gameHour = 6;
        }
    }
}
