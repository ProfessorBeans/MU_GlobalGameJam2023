using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VideoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VideoPlayCoroutine());
    }
    

    IEnumerator VideoPlayCoroutine()
    {
        yield return new WaitForSeconds(123f);
        SceneManager.LoadScene("Title_Screen");
    }
}
