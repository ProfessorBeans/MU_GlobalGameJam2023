using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class NodeController : MonoBehaviour
{
    //State Tracking
    public bool isOn;
    public GameObject snake;
    
    //Start
    private void Start()
    {
        isOn = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SnakeMovement>())
        {
            GetComponent<SpriteResolver>().SetCategoryAndLabel("New Category", "green");
            isOn = true;
        }
    }
}
