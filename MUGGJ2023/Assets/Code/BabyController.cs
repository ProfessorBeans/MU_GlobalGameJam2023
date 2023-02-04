using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    //outlets
    public Rigidbody2D _rb;
    
    //state tracking
    public float _deathTimer;
    
    //Start
    public void Awake()
    {
        _rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _deathTimer += (1 * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector2.right * 450f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector2.left * 450f * Time.deltaTime);
        }

        if (_deathTimer > 10f)
        {
            Destroy(gameObject);
        }
    }
}
