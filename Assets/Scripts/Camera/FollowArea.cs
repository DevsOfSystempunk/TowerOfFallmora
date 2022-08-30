using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArea : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<PlayerController>().CurArea = this;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<PlayerController>().CurArea = null;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
    }
}
