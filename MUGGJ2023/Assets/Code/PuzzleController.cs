using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;
using UnityEngine.UIElements;

public class PuzzleController : MonoBehaviour
{
    //outlets
    public GameObject _vines;
    public GameObject _player;

    public GameObject fish;
    public GameObject _lily1;
    public GameObject _lily2;
    public GameObject _lily3;

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
            _lily1.GetComponent<SpriteResolver>().SetCategoryAndLabel("lily", "Entry_0");
            _lily2.GetComponent<SpriteResolver>().SetCategoryAndLabel("lily", "Entry_0");
            _lily3.GetComponent<SpriteResolver>().SetCategoryAndLabel("lily", "Entry_0");
            _player.GetComponent<PlayerMovementControls>().enabled = true;
            _player.GetComponent<PlayerMovementControls>().isRooted = false;

            fish.GetComponent<FishController>().enabled = false;
        }

        if (_vines.GetComponent<Rigidbody2D>())
        {
            print("BabyMakerFound");

            _vines.GetComponent<BabyMakerControls>()._isActive = true;
        }

        if (_vines.GetComponent<Animator>())
        {
            print("ok");
            SceneManager.LoadScene("Final cutscenes");
        }
    }
}
