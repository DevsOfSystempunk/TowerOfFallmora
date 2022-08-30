using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string DialogueName;
    public List<string> Sentences;
    public DialogueType Type;
    public Conditions Conditions;
    public Collider2D collider;
    public bool PlayerIn = false;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && PlayerIn)
        {
            DialogueController.Instance.enabled = true;
            DialogueController.Instance.Animator.SetBool("K", true);

            DialogueController.Instance.Name.text = DialogueName;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            switch (Type)
            {
                case DialogueType.Obrigatorio:
                    break;
                case DialogueType.Interagivel:
                    Player.Instance.interfaces.Message.text = "Interagir";
                    Player.Instance.interfaces.Message.enabled = true;
                    Debug.Log("InDialogue Trigger");
                    PlayerIn = true;
                    break;
                case DialogueType.Condicional:
                    break;
            }
        }
    }

}
