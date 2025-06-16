using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    public float spawnInterval = 25f;

    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (currentIndex < hiddenObjects.Length)
        {
            yield return new WaitForSeconds(spawnInterval);

            hiddenObjects[currentIndex].SetActive(true);
            currentIndex++;
        }
    }
}
