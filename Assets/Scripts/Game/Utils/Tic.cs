using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tic : MonoBehaviour
{
    public static Tic Instance { get; private set; }
    public float CurrentTime;
    public Light light;
    public float tic;
    public float ticAguardo;
    public bool ticed;
    
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tic) {
            tic = Time.time + ticAguardo;
            ticed = true;
        }
        else
        {
            ticed = false;
        }
    }
}
