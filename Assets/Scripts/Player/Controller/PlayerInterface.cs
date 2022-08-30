using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    public static PlayerInterface Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ReturnToMain()
    {
        var controller = Inventory.GetComponent<InterfaceController>();
        controller.CloseAll();
        controller.Abas[0].SetActive(true);
    }
    public void ToggleThis(Canvas canvas) { 
        canvas.enabled = !canvas.enabled;
    }
    public Canvas Inventory;
    public Canvas Menu;
    public Canvas HUD;
    public Canvas Dialogue;
    public TMP_Text Message;
    public void TooggleMessage() {
        Message.enabled = !Message.enabled;
    }
}
