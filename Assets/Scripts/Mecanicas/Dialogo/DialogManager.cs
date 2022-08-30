using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogText;
    public Animator animator;
    Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            DisplayNextSentence();
        }
    }
	public void StartDialogue(Dialog dialogue)
	{

		animator.SetBool("IsOpen", true);
		nameText.text = dialogue.name;
		Player.Instance.interfaces.Dialogue.GetComponent<GameObject>().SetActive(true);
		
		sentences = new Queue<string>(dialogue.sentences);
		
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		Player.Instance.interfaces.Dialogue.GetComponent<GameObject>().SetActive(false);
		GameManager.instance.GameState = GameStates.InGame;
	}
}
