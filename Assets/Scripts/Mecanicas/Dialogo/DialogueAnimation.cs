using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimation : MonoBehaviour
{
    public Dialog Dialog;
    public DialogManager DialogManager;
    public void TriggerDialogue() {
        DialogManager.StartDialogue(Dialog);
        Debug.Log("Dialogue Trigger");
    }
}
