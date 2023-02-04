using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyMakerControls : MonoBehaviour
{
    public GameObject _baby;
    public bool _deadBaby;
    public bool _isActive;
    public float _deathTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        _deadBaby = true;
        _isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive == true)
        {
            if (Input.GetKey(KeyCode.Space) && _deadBaby == true)
            {
                Instantiate(_baby);
                _deadBaby = false;
            }
        }
        if (_deadBaby == false)
        {
            _deathTimer += (1f * Time.deltaTime);
        }

        if (_deathTimer > 10f)
        {
            _deadBaby = true;
            _deathTimer = 0f;
        }
    }
}
