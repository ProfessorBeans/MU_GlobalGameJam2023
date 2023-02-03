using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using System.Collections.Generic;
using System.Security.Cryptography;

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

    private void Start()
    {
        //Get components
        _rb = GetComponent<Rigidbody2D>();
        _trans = GetComponent<Transform>();
        isActive = false;
    }

    private void FixedUpdate()
    {
        if (isActive == true)
        {
            //Move forward (Down) at a constant Speed
            _trans.Translate(0, _ySpeed, 0);

            //Rotate Left/Right
            if (Input.GetKey(KeyCode.A))
            {
                _trans.Rotate(Vector3.back);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _trans.Rotate(Vector3.forward);
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
            print("Hit Tail");
            _dirtMount.GetComponent<DirtMount>().SnakeReset();
        }
    }

}
