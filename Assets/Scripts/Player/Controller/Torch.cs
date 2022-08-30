using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light;
    public float tic, nexttic;
    public static Torch torch;
    public float ShiftToValue;
    private void Awake()
    {
        torch = this;
    }
    private void Update()
    {
        if (Time.time >= nexttic)
        {
            nexttic = Time.time + tic;
            Vector2 v = new Vector2(Random.Range(0.1f, 1.5f), 0);
            v = Vector2.MoveTowards(new Vector2(light.intensity, 0), v, ShiftToValue * Time.deltaTime);
            light.intensity = v.x;
        }
    }

}
