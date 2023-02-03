using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineControls : MonoBehaviour
{
    //Outlets
    public GameObject _player; //PLAYER MUST BE SET PER PUZZLE PER SCENE

    //State Tracking
    public bool _isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        _isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive == true)
        {
            if (Input.GetKey(KeyCode.S))
            {
                print("Don't tempt fate, boy.");
            }
        }
    }
}
