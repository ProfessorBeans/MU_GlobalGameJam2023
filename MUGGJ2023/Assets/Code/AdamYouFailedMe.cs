using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdamYouFailedMe : MonoBehaviour
{
    //Outlets
    public string _scene;
    
    //Collison
    public void OnTriggerEnter2D(Collider2D other)
    {
        print("u moom");
        if (other.GetComponent<PlayerMovementControls>())
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
