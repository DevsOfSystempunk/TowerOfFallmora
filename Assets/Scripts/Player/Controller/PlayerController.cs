using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerValues))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerInterface))]
[RequireComponent(typeof(PlayerStyle))]

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance { get; set; }
    public FollowArea CurArea;
    internal Rigidbody2D rigidbody2D;
    internal Animator animator;
    internal SpriteRenderer spriteRenderer;
    public PlayerIn PlayerIn;
    internal float ticVelocidade;

    public Vector2 ForceVelocity;
    public void Awake()
    {
        Instance = this;
        ForceVelocity = Vector2.zero;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurArea = null;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        switch (PlayerIn) {
            case PlayerIn.InDoor:
                Player.Instance.interfaces.Message.text = "Entrar";
                break;
            case PlayerIn.InColectable:
                Player.Instance.interfaces.Message.text = "Coletar";
                break;
            case PlayerIn.InInteractable:
                Player.Instance.interfaces.Message.text = "Interagir";
                break;
            default:
                Player.Instance.interfaces.Message.text = "";
                break;
        }
        if (Input.GetKeyDown(KeyCode.P)) { Player.Instance.interfaces.ToggleThis(Player.Instance.interfaces.Menu); }
        // Depende do jogo estar valido
        if (GameManager.instance.ProcedGame())
        {
            PlayerInput.Instance.GetInputsFromInterface();
            switch (GameManager.instance.GameState)
            {
                case GameStates.InGame:
                    InGame();
                    break;
                case GameStates.InDialogue:
                    InDialogue();
                    break;
                case GameStates.InMenu:
                    InMenu();
                    break;
                default:
                    break;
            }
        }
    }
    void InGame()
    {
        if (Input.GetButton("Horizontal"))
        {
            float time = Time.time;
            if (time >= ticVelocidade + 0.05)
            {
                ticVelocidade = Time.time;
                PlayerValues.Instance.Velocidade.x += (System.Math.Abs(Input.GetAxis("Horizontal")) * PlayerValues.Instance.Aceleracao);
                Debug.Log(PlayerValues.Instance.Velocidade.x);
                if (PlayerValues.Instance.Velocidade.x >= PlayerValues.Instance.VelocidadeMaxima)
                {
                    PlayerValues.Instance.Velocidade.x = PlayerValues.Instance.VelocidadeMaxima;
                }

            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                ForceVelocity.x = PlayerValues.Instance.Velocidade.x;
                spriteRenderer.flipX = false;
            }
            else
            {
                ForceVelocity.x = -PlayerValues.Instance.Velocidade.x;
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            ForceVelocity.x = 0;
            PlayerValues.Instance.Velocidade.x = 0;
        }
        
        animator.SetFloat("Speed",System.Math.Abs(ForceVelocity.x));
        animator.speed = System.Math.Abs(ForceVelocity.x) <= 1 ? 1 : (System.Math.Abs(ForceVelocity.x))/10;
        Divisor = (System.Math.Abs(ForceVelocity.x)) / 10;
        rigidbody2D.velocity = ForceVelocity;
    }
    [Range(0,100)]
    public float Divisor;
    void InDialogue() { }
    public DialogueAnimation GoToDialogue(Dialog dialog) {
        Player.Instance.interfaces.Dialogue.GetComponent<DialogueAnimation>().Dialog = dialog;
        
        return Player.Instance.interfaces.Dialogue.GetComponent<DialogueAnimation>();
    }
    void InMenu() { }
}
