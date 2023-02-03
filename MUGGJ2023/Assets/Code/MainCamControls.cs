using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamControls : MonoBehaviour
{
    //State Tracking
    public bool isLookingRoots;

    private void Start()
    {
        isLookingRoots = false;
    }

    public void PanToRoots()
    {
        isLookingRoots = true;
        this.GetComponent<Transform>().Translate(0, -6, 0);
        print("Pan to Roots");
    }

    public void PanToSeedBoy()
    {
        isLookingRoots = false;
        this.GetComponent<Transform>().Translate(0, 6, 0);
        print("Pan to SeedBoy");
    }
}
