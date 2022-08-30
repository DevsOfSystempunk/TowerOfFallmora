using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.PointerEventData;

public class PlayerInput : MonoBehaviour
{

    public static PlayerInput Instance { get; set; }

    public bool HaveControl = true;
    public bool DebugMenuIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
 
    public void GetInputsFromInterface()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            PlayerInterface.Instance.Inventory.enabled = !PlayerInterface.Instance.Inventory.enabled;
            if (PlayerInterface.Instance.Inventory.enabled)
            {
                GameManager.instance.GoToMenu();
            }
            else
            {
                GameManager.instance.GoToGame();
            }
        }
        
    }
}
