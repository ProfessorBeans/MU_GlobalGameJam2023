using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishController : MonoBehaviour
{
    //Variables
    public float fishSpeedSlow;
    public float fishSpeedFast;
    public float rotateAngle = 0f;



    // Update is called once per frame
    void FixedUpdate()
    {
        //Tests the angle and speeds up fish if it's above 90 degrees
        if (rotateAngle >= 0.5f)
        {
            transform.Rotate(new Vector3(0, 0, 10), fishSpeedFast * Time.deltaTime);
            rotateAngle = gameObject.transform.rotation.z;
        }
        else if(transform.rotation.z <= 0.5f)
        {
            transform.Rotate(new Vector3(0, 0, 10), fishSpeedSlow * Time.deltaTime);
            rotateAngle = gameObject.transform.rotation.z;
        }
        
        //Makes sure value is positive
        if (rotateAngle < 0)
        {
            rotateAngle *= -1f;
        }
    }

}
