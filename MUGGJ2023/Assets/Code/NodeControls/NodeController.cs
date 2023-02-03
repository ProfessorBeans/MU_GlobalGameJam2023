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

    public void Update()
    {
        if (isOn == true)
        {
            GetComponent<SpriteResolver>().SetCategoryAndLabel("New Category", "green");
        }

        if (isOn == false)
        {
            GetComponent<SpriteResolver>().SetCategoryAndLabel("New Category", "black");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SnakeMovement>())
        {
            isOn = true;
        }
    }
}
