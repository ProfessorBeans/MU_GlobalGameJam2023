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
        myX = this.GetComponent<Transform>().position.x;
        myY = this.GetComponent<Transform>().position.y;
    }

    public void SnakeReset()
    {
        _snake.position = this.GetComponent<Transform>().position;
        _snake.rotation = new Quaternion(0, 0, 0, 0);
        _snake.gameObject.GetComponent<SnakeMovement>().isActive = false;
        _snake.gameObject.GetComponent<SnakeMovement>().player.GetComponent<PlayerMovementControls>().isRooted = false;
        _trailGen.GetComponent<TrailRenderer>().Clear();
        _trailCol.GetComponent<EdgeCollider2D>().Reset();
    }

}
