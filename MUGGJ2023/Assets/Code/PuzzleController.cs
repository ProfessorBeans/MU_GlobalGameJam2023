using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleController : MonoBehaviour
{
    //outlets
    public GameObject _vines;
    public GameObject _player;

    public void EnableVineControls()
    {
        if (_vines.GetComponent<VineControls>())
        {
            _vines.GetComponent<VineControls>()._isActive = true;
            print("vines enabled");
        }

        if (_vines.GetComponent<BoxCollider2D>())
        {
            _vines.GetComponent<BoxCollider2D>().enabled = true;
            _player.GetComponent<PlayerMovementControls>().enabled = true;
            _player.GetComponent<PlayerMovementControls>().isRooted = false;
        }

        if (_vines.GetComponent<Rigidbody2D>())
        {
            print("BabyMakerFound");

            _vines.GetComponent<BabyMakerControls>()._isActive = true;
        }
        
    }
}
