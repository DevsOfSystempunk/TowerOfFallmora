using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    InGame,
    InMenu,
    InDialogue
}
public class GameManager : MonoBehaviour
{
    public GameStates GameState;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        GoToGame();
        Camera.main.backgroundColor = Color.black;
    }
    //Verificar e validar qualquer coisa que possa atrapalhar no andamento do jogo
    public bool ProcedGame()
    {
        return true;
    }
    public void GoToGame()
    {
        ChangeGameState(GameStates.InGame);
        LockMouse();
    }
    public void GoToMenu()
    {
        ChangeGameState(GameStates.InMenu);
        UnlockMouse();
    }
    public void GoToDialogue()
    {
        ChangeGameState(GameStates.InDialogue);
        UnlockMouse();
    }
    internal void LockMouse() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    internal void UnlockMouse() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    internal void ChangeGameState(GameStates NewState)
    {
        
        GameState = NewState;
    }
}
