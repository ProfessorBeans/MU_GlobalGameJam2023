using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    //state tracking
    public bool isHeld;
    public float _boulderSpeed;
    
    public void Start()
    {
        isHeld = false;
        _boulderSpeed = 3f;
    }

    public void Update()
    {
        if (isHeld == true)
        {
            if (Input.GetKey(KeyCode.W) && this.transform.position.y < 12f)
            {
                this.transform.Translate(0, _boulderSpeed * Time.deltaTime, 0);
                    //Previous speed 0.0125
            }
        }
    }
}
