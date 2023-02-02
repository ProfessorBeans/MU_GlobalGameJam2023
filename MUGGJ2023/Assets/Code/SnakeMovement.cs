using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour
{
    //Variables
    public Rigidbody2D _rb;
    public Transform _trans;
    public float _ySpeed;
    public float _rotateSpeed;
    public Transform segmentPrefab;
    
    //Segments
    private List<Transform> _segments;
    
    private void Start()
    {
        //Get components
        _rb = GetComponent<Rigidbody2D>();
        _trans = GetComponent<Transform>();

        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
    }
    
    private void Update()
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
        
        //Testing Grow Function
        if (Input.GetKey(KeyCode.F))
        {
            Grow();
        }
    }
}
