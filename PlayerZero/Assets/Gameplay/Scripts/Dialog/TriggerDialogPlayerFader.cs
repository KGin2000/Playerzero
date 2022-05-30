using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogPlayerFader : MonoBehaviour
{
    private void OnTriggerEnter (Collider collision)
    {
    ObscuringDialogPlayerFader[] obscuringDialogPlayerFader = collision.gameObject.GetComponentsInChildren<ObscuringDialogPlayerFader>();

        if (obscuringDialogPlayerFader.Length > 0)
        {
            for(int i=0; i<obscuringDialogPlayerFader.Length; i++)
            {
                obscuringDialogPlayerFader[i].FadeIn();
            }
        }
    }

    private void OnTriggerExit (Collider collision)
    {

        ObscuringDialogPlayerFader[] obscuringDialogPlayerFader = collision.gameObject.GetComponentsInChildren<ObscuringDialogPlayerFader>();

        if(obscuringDialogPlayerFader.Length > 0)
        {
            for (int i = 0; i < obscuringDialogPlayerFader.Length; i++)
            {
                obscuringDialogPlayerFader[i].FadeOut();
            }
        }
    }
}
