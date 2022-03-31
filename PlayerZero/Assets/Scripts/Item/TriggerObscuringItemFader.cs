
using UnityEngine;

public class TriggerObscuringItemFader : MonoBehaviour
{
    private void OnTriggerEnter (Collider collision)
    {
    ObscuringDialogFader[] obscuringDialogFader = collision.gameObject.GetComponentsInChildren<ObscuringDialogFader>();

        if (obscuringDialogFader.Length > 0)
        {
            for(int i=0; i<obscuringDialogFader.Length; i++)
            {
                obscuringDialogFader[i].FadeIn();
            }
        }
    }

    private void OnTriggerExit (Collider collision)
    {

        ObscuringDialogFader[] obscuringDialogFader = collision.gameObject.GetComponentsInChildren<ObscuringDialogFader>();

        if(obscuringDialogFader.Length > 0)
        {
            for (int i = 0; i < obscuringDialogFader.Length; i++)
            {
                obscuringDialogFader[i].FadeOut();
            }
        }
    }
}
