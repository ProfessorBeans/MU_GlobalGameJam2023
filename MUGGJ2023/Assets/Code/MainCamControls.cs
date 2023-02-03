using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        StartCoroutine(PanToRootsCoroutine());
        print("Pan to Roots");
    }

    public void PanToSeedBoy()
    {
        isLookingRoots = false;
        StartCoroutine(PanSeedBoyCoroutine());
        print("Pan to SeedBoy");
    }
    
    
    
    IEnumerator PanToRootsCoroutine()
    {
        Tween panDown = transform.DOMove(transform.position + (new Vector3(0, -6, 0)), 0.2f);
        yield return panDown.WaitForCompletion();
    }
    
    IEnumerator PanSeedBoyCoroutine()
    {
        Tween panUp = transform.DOMove(transform.position + (new Vector3(0, 6, 0)), 0.2f);
        yield return panUp.WaitForCompletion();
    }
}


