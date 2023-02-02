using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public TrailRenderer _line;

    //Check if a collider exists
    public void GenerateCollider()
    {
        //Check if collider exists
        MeshCollider _collider = GetComponent<MeshCollider>();
        
        //if no collider, create one
        if (_collider == null)
        {
            _collider = gameObject.AddComponent<MeshCollider>();
        }
        
        //Store the collider
        Mesh mesh = new Mesh();
        _line.BakeMesh(mesh, true);
        _collider.sharedMesh = mesh;
    }
    

    // Update is called once per frame
    void Update()
    {
        GenerateCollider();
    }
}
