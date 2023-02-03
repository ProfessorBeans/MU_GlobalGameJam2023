using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour
{
    public int maxObjects = 5;
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    private int currentPrefabIndex = 0;
    public float cameraSwitchDuration = 0.2f;
    public int currentCameraIndex=0;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& currentPrefabIndex < maxObjects)
        {
            SpawnPrefab();
            currentPrefabIndex++;
        }
        
        if (Input.GetKeyDown(KeyCode.Tab) && spawnedPrefabs.Count > 0)
        {
            currentPrefabIndex = (currentPrefabIndex + 1) % spawnedPrefabs.Count;
            CycleCamera();
        }

       
    }

    void SpawnPrefab()
        {
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            spawnedPrefabs.Add(spawnedPrefab);
        }

    public void CycleCamera()
    {
        int previousCameraIndex = currentCameraIndex;
        currentCameraIndex = (currentCameraIndex + 1) % spawnedPrefabs.Count;
        Camera previousCamera = spawnedPrefabs[previousCameraIndex].GetComponentInChildren<Camera>();
        Camera currentCamera = spawnedPrefabs[currentCameraIndex].GetComponentInChildren<Camera>();
        previousCamera.enabled = false;
        currentCamera.enabled = true;
        Invoke("ResetCamera", cameraSwitchDuration);
    }

    private void ResetCamera()
    {
        int previousCameraIndex = (currentCameraIndex + spawnedPrefabs.Count - 1) % spawnedPrefabs.Count;
        Camera previousCamera = spawnedPrefabs[previousCameraIndex].GetComponentInChildren<Camera>();
        previousCamera.enabled = true;
    }
    
}
