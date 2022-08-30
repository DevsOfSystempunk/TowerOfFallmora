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
        sent = new Queue<string>();
    }
    public void StartDialogue(string Name, string[] Sentenses) {
        Animator.SetBool("InDialogue", true);

        this.Name.text = Name;
        sent.Clear();

        foreach (string sentece in Sentenses) { 
            sent.Enqueue(sentece);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sent.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sent.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        Mess.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Mess.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {
        Animator.SetBool("InDialogue", false);
        
    }
}
