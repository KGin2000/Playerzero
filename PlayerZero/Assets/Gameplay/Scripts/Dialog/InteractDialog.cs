using UnityEngine;
using UnityEngine.UI;

public class InteractDialog : MonoBehaviour
{

    //[SerializeField] DialogContainer dialogue;
    [SerializeField] Text DialogText;
    [SerializeField] Text NameTalker;
    private bool Trig = false;
    private float vInput;
    private float hInput;
    private bool Enter = false;

    DialogDetails dialogDetails1;
    int i = 0;

    private void Update()
    {
        //Debug.Log("i = "+ i);
        // Debug.Log("Trig = " + Trig);
        if(Input.GetKeyDown(KeyCode.E) && Trig == true)
        {
            UIManager.Instance.EnableDialogBox();
            // GameManager.instance.dialogueSystem.Initialize(dialogue);
            Enter = true;
            Test(dialogDetails1);
            
        }
    }

    private void Test(DialogDetails dialogDetails)
    {
        int dialogStages = dialogDetails.DialogText.Length;

        if(Enter == true)
        {
            NameTalker.text = "[ " + dialogDetails.NameTalker + " ]";
            DialogText.text = "< " + dialogDetails.DialogText[i] + " >";
            //Debug.Log(dialogDetails.DialogText[i]); // >= daysCounter
        }
        i++;
        
        if(i >= dialogStages)
        {
            i = 0;
            UIManager.Instance.DisableDialogBox();
        } 
        Enter = false;     
    }

    private void OnTriggerEnter (Collider collision)
    {
        if(collision.gameObject.tag == "Dialog")
        {
            Trig = true;
        }

        Dialog dialog = collision.GetComponent<Dialog>();

        if(dialog != null)
        {
            //Get Dialog Details
            DialogDetails dialogDetails = DialogManager.Instance.GetDialogDetails(dialog.DialogCode);

            dialogDetails1 = dialogDetails;

            // Print
            // Debug.Log(dialogDetails.NameTalker);

            // Debug.Log(dialogDetails.DialogCode);

            // Debug.Log(dialogDetails.DialogText);
        }

    }
    private void OnTriggerExit (Collider collision)
    {
        Trig = false;
        // GameManager.instance.dialogueSystem.Conclude();
    }
}
