using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VineControls : MonoBehaviour
{
    //Outlets
    public GameObject _player; //PLAYER MUST BE SET PER PUZZLE PER SCENE
    public GameObject _stone;

    public AudioManager _audioManager;

    //State Tracking
    public bool _isActive;
    public float _speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _isActive = false;
        _speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive == true)
        {
            if (Input.GetKey(KeyCode.S) && this.transform.position.y > 4.5f && _stone.GetComponent<StoneController>().isHeld == false)
            {
                this.transform.Translate(0, -_speed * Time.deltaTime, 0);
                
                _audioManager.playVines();
            }
            if (Input.GetKey(KeyCode.W) && this.transform.position.y < 12f)
            {
                this.transform.Translate(0, _speed * Time.deltaTime, 0);
                
                _audioManager.playVines();
            }

            if (this.transform.position.y < 5 && this.transform.position.y > 4.5)
            {
                print("Between 6 and 5.5");
                _stone.GetComponent<StoneController>().isHeld = true;
            }

            if (this.transform.position.y > 11 && this.transform.position.y < 12 && _stone.GetComponent<StoneController>().isHeld == true)
            {
                _stone.GetComponent<StoneController>().isHeld = false;
                _isActive = false;
                _player.GetComponent<PlayerMovementControls>().enabled = true;
                _player.GetComponent<PlayerMovementControls>().isRooted = false;
            }
        }
    }
}
