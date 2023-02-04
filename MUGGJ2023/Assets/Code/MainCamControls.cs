using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCamControls : MonoBehaviour
{
    //State Tracking
    public bool isLookingRoots;

    public float panDuration;

    //Camera position limits for restricting movement
    public float camXLimit;
    public float camUpperYLimit;
    public float camLowerYLimit;

    private void Start()
    {
        isLookingRoots = false;

        //Set cam limit values to prevent it from shifting too far from intended position
        camXLimit = 6f;
        camUpperYLimit = 2f;
        camLowerYLimit = -4f;
    }

    private void Update()
    {
        Vector3 camPos = gameObject.transform.localPosition;
        if (camPos.x != camXLimit)
        {
            gameObject.transform.localPosition = new Vector3(camXLimit, camPos.y, -10);
        }
        if (camPos.y > camUpperYLimit)
        {
            gameObject.transform.localPosition = new Vector3(camPos.x, camUpperYLimit, -10);
        }
        if (camPos.y < camLowerYLimit)
        {
            gameObject.transform.localPosition = new Vector3(camPos.x, camLowerYLimit, -10);
        }
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
        Tween panDown = transform.DOMove(transform.position + (new Vector3(0, -6, 0)), panDuration);
        yield return panDown.WaitForCompletion();
    }
    
    IEnumerator PanSeedBoyCoroutine()
    {
        Tween panUp = transform.DOMove(transform.position + (new Vector3(0, 6, 0)), panDuration);
        yield return panUp.WaitForCompletion();
    }
}


