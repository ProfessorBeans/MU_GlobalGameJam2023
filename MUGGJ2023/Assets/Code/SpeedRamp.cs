using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    public float boostSpeed = 10f;

  
    
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
          rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + boostSpeed);
        }
    }
}
