using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public float dirtY;
    public float dirtX;
    public EdgeCollider2D _col;
    
    // Start is called before the first frame update
    void Start()
    {
        _col = this.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_col.offset.x != dirtX || _col.offset.y != dirtY)
        {
            _col.offset.x = dirtX;
            _col.offset.y = dirtY;
        }
    }
}
