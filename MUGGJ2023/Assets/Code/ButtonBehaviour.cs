using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color pressedColor = Color.gray;
    private Color originalColor;
    public float colorDuration = 0.1f;
    private bool isPressed = false;
    public GameObject _player;

    public GameObject _babyMaker;
    public GameObject _door;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BabyController>() && !isPressed)
        {
            isPressed = true;
            spriteRenderer.color = pressedColor;
            Invoke("ResetColor", colorDuration);
        }
    }

    private void Update()
    {
        if (isPressed == true)
        {
            Destroy(_door);
            _babyMaker.GetComponent<BabyMakerControls>()._isActive = false;
            _player.GetComponent<PlayerMovementControls>().enabled = true;
            _player.GetComponent<PlayerMovementControls>().isRooted = false;
        }
    }

    private void ResetColor()
    {
        spriteRenderer.color = originalColor;
        isPressed = false;
    }
}
