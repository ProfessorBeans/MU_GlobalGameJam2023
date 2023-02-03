using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color pressedColor = Color.gray;
    private Color originalColor;
    public float colorDuration = 0.1f;
    private bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            spriteRenderer.color = pressedColor;
            Invoke("ResetColor", colorDuration);
        }
    }
    
    private void ResetColor()
    {
        spriteRenderer.color = originalColor;
        isPressed = false;
    }
}
