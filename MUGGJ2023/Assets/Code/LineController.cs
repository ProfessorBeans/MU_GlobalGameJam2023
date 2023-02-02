using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LineController : MonoBehaviour
{
    public TrailRenderer myTrail;
    public EdgeCollider2D myCollider;

    public GameObject _colliderHolder;

    private void Start()
    {
        myTrail = GetComponent<TrailRenderer>();
    }

    private void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();
        myCollider = _colliderHolder.GetComponent<EdgeCollider2D>();
    }

    public void Update()
    {
        SetCollider(myTrail, myCollider);
    }

    public void SetCollider(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        for (int position = 0; position < trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }
}
