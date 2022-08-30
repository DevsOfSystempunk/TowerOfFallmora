using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public enum DialogueType { 
    Obrigatorio,
    Interagivel,
    Condicional
}
public enum Conditions { 
    Nenhuma,
    EstarComTochaNaMao
}
public class DialogController : MonoBehaviour
{
    public DialogueType Type;
    public DialogueAnimation Trigger;
    public Conditions Conditions;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Trigger = collision.GetComponent<PlayerController>().GoToDialogue(gameObject.GetComponent<Dialog>());
            if (Type == DialogueType.Interagivel)
            {
                InteractDialogueSelector(Trigger);
                Player.Instance.interfaces.Message.text = "Conversar";
                Player.Instance.interfaces.Message.enabled = true;
                GameManager.instance.GameState = GameStates.InDialogue;
            }
            else if (Type == DialogueType.Obrigatorio)
            {
                TriggerDialogueSelector(Trigger);
                GameManager.instance.GameState = GameStates.InDialogue;
            }
            else if (Type == DialogueType.Condicional)
            {
                if (CheckCondition())
                {
                    TriggerDialogueSelector(Trigger);
                }
            }
        }
    }
    public bool CheckCondition()
    {
        switch (Conditions)
        {
            case Conditions.Nenhuma:
                return true;
            case Conditions.EstarComTochaNaMao:
                return !PlayerController.Instance.gameObject.GetComponentInChildren<Torch>().GetComponent<Light>().enabled;
                break;
            default:
                return false;

        }
    }
    public void TriggerDialogueSelector(DialogueAnimation trigger)
    {
        trigger.TriggerDialogue();
    }
    public void InteractDialogueSelector(DialogueAnimation trigger)
    {

        if (Input.GetKeyDown("Interact"))
        {
            trigger.TriggerDialogue();
        }
    }

}
