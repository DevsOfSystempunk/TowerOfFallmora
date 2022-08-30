using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public static PlayerValues Instance { get; set; }
    public void Awake()
    {
        Instance = this;
    }

    // Valores
    public Locais CurrentLocal;
    public Vector2 Velocidade;
    public float Aceleracao;
    public float VelocidadeMaxima;
    public float SlowVelocidade;
    public int Vida;
    public int Forca;
}
