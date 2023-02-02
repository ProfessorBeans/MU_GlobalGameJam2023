using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DirtMount : MonoBehaviour
{
    //Outlets/Variables
    public Transform _snake;
    public GameObject _trailGen;
    public GameObject _trailCol;

    public float myX;
    public float myY;

    public float colliderX;
    public float colliderY;

    public void Start()
    {
        _trailCol.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
        myX = this.GetComponent<Transform>().position.x;
        myY = this.GetComponent<Transform>().position.y;
    }

    public void SnakeReset()
    {
        _snake.position = this.GetComponent<Transform>().position;
        _trailGen.GetComponent<TrailRenderer>().Clear();
        _trailCol.GetComponent<EdgeCollider2D>().Reset();
    }

    public void Update()
    {
        print(this.GetComponent<Transform>().position);
    }
}
