using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;

public class HolderController : MonoBehaviour
{
    //Outlets
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public GameObject _snake;
    public GameObject _mainCam;
    public GameObject _player;
    public GameObject _dirtMound;

    //PLANT MUST BE SET IN INSPECTOR
    public GameObject _puzzle;
    
    public void ResetNodes()
    {
        node1.GetComponent<NodeController>().isOn = false;
        node2.GetComponent<NodeController>().isOn = false;
        node3.GetComponent<NodeController>().isOn = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (node1.GetComponent<NodeController>().isOn == true && node2.GetComponent<NodeController>().isOn && node3.GetComponent<NodeController>().isOn && _mainCam.GetComponent<MainCamControls>().isLookingRoots == true)
        {
            print("Puzzle solved.");
            _dirtMound.GetComponent<CircleCollider2D>().enabled = false;
            _snake.GetComponent<SnakeMovement>().enabled = false;
            _player.GetComponent<PlayerMovementControls>().enabled = false;
            _puzzle.GetComponent<PuzzleController>().EnableVineControls();
        }
    }
}
