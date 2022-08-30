using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance;
    public TMP_Text Name;
    public TMP_Text Mess;
    public Animator Animator;
    public Queue<string> sent;
    public Dialogue Dialogue;
    
    public DialogueController() {
        Instance = this;
    }
    public void StartDialogue(string Name, List<string> Sentenses) {
        gameObject.active = true;
        Animator.SetBool("InDialogue", true);
        this.Name.text = Name;
        sent = new Queue<string>(Sentenses);

        foreach (string sentece in sent) { 
            sent.Enqueue(sentece);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sent.Count == 0) {
            EndDialogue();
            return;
        }

    }
    public void EndDialogue() {
        Animator.SetBool("InDialogue", false);
        gameObject.active = false;
        
    }
}
