using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerData : MonoBehaviour
{
    public int Life;
    public Locais LastPlace;
    public int Force;
    public float Aceleracao;
    public float VelocidadeMaxima;

    public void SetValues() {
        Life = PlayerValues.Instance.Vida;
        LastPlace = PlayerValues.Instance.CurrentLocal;
        Force = PlayerValues.Instance.Forca;
        Aceleracao = PlayerValues.Instance.Aceleracao;
        VelocidadeMaxima = PlayerValues.Instance.VelocidadeMaxima;
    }
}
