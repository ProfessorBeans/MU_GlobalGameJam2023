using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LilyPad
{
    public class PuzzleController : MonoBehaviour
    {
        //outlets
        public GameObject _bridge;

        public void Start()
        {
            _bridge.GetComponent<BoxCollider2D>().enabled = false;
        }

        public void EnableVineControls()
        {
            _bridge.GetComponent<BoxCollider2D>().enabled = true;
            print("bridge enabled");
        }
    }
}


