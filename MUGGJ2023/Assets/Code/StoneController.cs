using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    //state tracking
    public bool isHeld;

    public void Start()
    {
        isHeld = false;
    }

    public void Update()
    {
        if (isHeld == true)
        {
            if (Input.GetKey(KeyCode.W) && this.transform.position.y < 12f)
            {
                this.transform.Translate(0, 0.0125f, 0);
            }
        }
    }
}
