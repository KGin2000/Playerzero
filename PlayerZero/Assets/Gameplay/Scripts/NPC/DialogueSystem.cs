using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : SingletonMonobehaviour<DialogueSystem>
{
    public bool ShopEnter = true;
    [SerializeField] Text targetText;
    [SerializeField] Text nameText;
    [SerializeField] Image portrait;


    DialogContainer currentDialogue;
    int currentTextLine;

    [Range(0f,1f)]
    [SerializeField] float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PushText();
        }
        TypeOutText();

        // if (Input.GetKeyDown(KeyCode.B))
        //     Debug.Log("B key was pressed.");
    }

    public bool GetSomeBoolean()
    {
        return ShopEnter;
    }

    private void TypeOutText()
    {
        if (currentTime >= totalTimeToType)
        {
            return;
        }
        currentTime += Time.deltaTime;
        float progress = currentTime / totalTimeToType;
        progress = Mathf.Clamp(progress, 0, 1f);
        int letterCount = (int)(lineToShow.Length * progress);
        targetText.text = lineToShow.Substring(0, letterCount);
    }

    private void PushText()
    {
        currentTextLine += 1;
        if (currentTextLine >= currentDialogue.line.Count)
        {
            Conclude();
        }
        else
        {
            lineToShow = currentDialogue.line[currentTextLine];
            totalTimeToType = lineToShow.Length * timePerLetter;
            currentTime = 0f;
            targetText.text = "";
        }
    }

    public void Initialize(DialogContainer dialogContainer)
    {
        Show(true);
        // ShopEnter = true;
        // Debug.Log("Shop" + ShopEnter);
        currentDialogue = dialogContainer;
        currentTextLine = -1;
        PushText();
        UpdatePortrait();

        Player.Instance.canShootCrossbow = false;       //Set Crossbow
    }

    private void UpdatePortrait()
    {
        portrait.sprite = currentDialogue.actor.portrait;
        nameText.text = currentDialogue.actor.Name;
    }

    private void Show(bool value)
    {
        gameObject.SetActive(value);
    }

    public void Conclude()
    {
        // Debug.Log("The dialog has ended");
        // ShopEnter = false;
        // Debug.Log("Shop" + ShopEnter);
        Show(false);
        Player.Instance.canShootCrossbow = true;       //Set Crossbow
    }
}
