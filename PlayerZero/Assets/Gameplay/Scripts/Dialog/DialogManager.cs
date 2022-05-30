using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : SingletonMonobehaviour<DialogManager>
{
    [SerializeField] private SO_DialogList dialogList = null;
    [HideInInspector] public DialogDetails dialogDetails;

    private Dictionary<int, DialogDetails> dialogDetailsDictionary;

    private void Start()
    {
        CreateDialogDetailsDictionary();
    }

    private void CreateDialogDetailsDictionary()
    {
        dialogDetailsDictionary = new Dictionary<int, DialogDetails>();

        foreach (DialogDetails dialogDetails in dialogList.dialogDetails)
        {
            dialogDetailsDictionary.Add(dialogDetails.DialogCode, dialogDetails);
        }
    }

    public DialogDetails GetDialogDetails(int dialogCode)
    {
        DialogDetails dialogDetails;

        if (dialogDetailsDictionary.TryGetValue(dialogCode, out dialogDetails))
        {
            return dialogDetails;
        }

        else
        {
            return null;
        }
        
    }
}
