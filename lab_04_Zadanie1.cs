using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public GameObject block; 
    public Material[] materials; 
    public int numberOfBlocks = 10; 
    public float delay = 3.0f; 
    public GameObject platform; 

    private List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        if (platform == null)
        {
            Debug.LogError("Nie wskazano obiektu platformy.");
            return;
        }

        Renderer renderer = platform.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Brak komponentu Renderer na obiekcie platformy. Skrypt nie mo¿e dzia³aæ poprawnie.");
            return;
        }

        Bounds bounds = renderer.bounds;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            float randomX = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = UnityEngine.Random.Range(bounds.min.z, bounds.max.z);
            positions.Add(new Vector3(randomX, 5, randomZ));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);
            
            Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(delay);
        }
    }
}
