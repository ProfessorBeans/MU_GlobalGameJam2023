using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderController : MonoBehaviour
{
    //Outlets
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;

    // Update is called once per frame
    void Update()
    {
        if (node1.GetComponent<NodeController>().isOn == true && node2.GetComponent<NodeController>().isOn && node3.GetComponent<NodeController>().isOn)
        {
            print("Puzzle solved.");
        }
    }
}
