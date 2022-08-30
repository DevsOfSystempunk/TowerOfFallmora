using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public static InterfaceController Instance;
    public List<GameObject> Abas;
    private void Awake()
    {
        Instance = this;
    }
    public void CloseAll() {
        foreach (GameObject go in Abas)
        {
            go.SetActive(false);
        }
    }
    
}
