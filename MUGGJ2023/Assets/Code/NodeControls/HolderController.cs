using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HolderController : MonoBehaviour
{
    //Outlets
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public GameObject _snake;

    //PLANT MUST BE SET IN INSPECTOR
    public GameObject _plant;
    
    public void ResetNodes()
    {
        node1.GetComponent<NodeController>().isOn = false;
        node2.GetComponent<NodeController>().isOn = false;
        node3.GetComponent<NodeController>().isOn = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (node1.GetComponent<NodeController>().isOn == true && node2.GetComponent<NodeController>().isOn && node3.GetComponent<NodeController>().isOn)
        {
            print("Puzzle solved.");
            _plant.GetComponent<SpriteRenderer>().enabled = true;
            _snake.GetComponent<SnakeMovement>().isActive = false;
        }
    }
}
