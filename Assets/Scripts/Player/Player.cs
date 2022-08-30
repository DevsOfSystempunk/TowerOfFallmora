using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerIn
{
    InDoor,
    InColectable,
    InInteractable,
    NAN
}
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerInterface))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerStyle))]
[RequireComponent(typeof(PlayerValues))]
public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerInput inputs;
    public PlayerInterface interfaces;
    public PlayerInventory inventory;
    public PlayerStyle style;
    public PlayerValues values;
    
    public static Player Instance;
    public Player()
    {
        Instance = this;
    }

}
