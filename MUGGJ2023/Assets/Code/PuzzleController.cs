using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    //outlets
    public GameObject _vines;

    public void EnableVineControls()
    {
        _vines.GetComponent<VineControls>()._isActive = true;
        print("vines enabled");
    }
}
