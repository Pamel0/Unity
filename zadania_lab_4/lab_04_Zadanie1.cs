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
            Debug.LogError("Brak komponentu Renderer na obiekcie platformy");
            return;
        }

        Bounds bounds = renderer.bounds;

        Renderer blockRenderer = block.GetComponent<Renderer>();
        if (blockRenderer == null)
        {
            Debug.LogError("Brak komponentu Renderer na obiekcie block");
            return;
        }

        float blockHeight = blockRenderer.bounds.size.y;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            float randomX = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = UnityEngine.Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.min.y + (blockHeight / 2);

            positions.Add(new Vector3(randomX, randomY, randomZ));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
