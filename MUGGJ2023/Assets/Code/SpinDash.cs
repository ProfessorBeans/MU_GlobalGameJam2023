using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDash : MonoBehaviour
{
    public float dashSpeed;
    private Rigidbody2D rb;
    private bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        if (hit.collider != null)
        { 
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeAngle !=0)
            {
                float slope = Mathf.Sign(slopeAngle);
                //Debug.Log("slope angle is"+ slopeAngle);
                rb.velocity = new Vector2(rb.velocity.x, slope * dashSpeed);
               }

            Debug.Log("slope angle is" + slopeAngle);
            if (Input.GetKeyDown(KeyCode.Space)&&!isDashing)
             {
                isDashing = true;
                Debug.Log(isDashing);
                float horizontalInput = Input.GetAxis("Horizontal");

               rb.velocity = new Vector2(dashSpeed*horizontalInput, 0);
              }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDashing = false;
        rb.velocity = Vector2.zero;
    }
}
