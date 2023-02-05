using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using System.Security.Cryptography;
using UnityEditor;

public class SnakeMovement : MonoBehaviour
{
    //Variables
    public Rigidbody2D _rb;
    public Transform _trans;
    public float _ySpeed;
    public float _rotateSpeed;
    public GameObject _dirtMount;
    public bool isActive;
    public GameObject player;

    public AudioManager _audioManager;
    
    private void Start()
    {
        //Get components
        _rb = GetComponent<Rigidbody2D>();
        _trans = GetComponent<Transform>();
        isActive = false;
    }

    private void Update()
    {
        if (isActive == true)
        {
            //Move forward (Down) at a constant Speed
            _trans.Translate(0, _ySpeed * Time.deltaTime, 0);

            //Rotate Left/Right
            if (Input.GetKey(KeyCode.A))
            {
                _trans.Rotate(Vector3.back,45 * _rotateSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _trans.Rotate(Vector3.forward, 45 * _rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            if(player.GetComponent<PlayerMovementControls>().isRooted)
            {
                isActive = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EdgeCollider2D>())
        {
            //print("Hit Tail");
            
            _audioManager.playLoseVoice();
                
            _dirtMount.GetComponent<DirtMount>().SnakeReset();
        }
    }

}
