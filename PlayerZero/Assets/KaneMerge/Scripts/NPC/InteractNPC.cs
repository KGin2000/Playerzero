using UnityEngine;

public class InteractNPC : MonoBehaviour
{

    [SerializeField] DialogContainer dialogue;
    public bool Trig = false;
    private float vInput;
    private float hInput;
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Trig == true)
        {
            GameManager.instance.dialogueSystem.Initialize(dialogue);
        }
    }
    

    private void OnTriggerEnter (Collider collision)
    {
        Trig = true;
        
    }
    private void OnTriggerExit (Collider collision)
    {
        Trig = false;
        GameManager.instance.dialogueSystem.Conclude();
    }
}