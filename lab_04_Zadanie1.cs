using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public GameObject block; // obiekt do generowania
    public Material[] materials; // tablica materia³ów
    public int numberOfBlocks = 10; // liczba obiektów do generowania
    public float delay = 3.0f; // opóŸnienie
    public GameObject platform; // obiekt platformy

    private List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        // Sprawdzamy, czy platforma ma komponent Renderer
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

        // Pobieramy rozmiar platformy
        Bounds bounds = renderer.bounds;

        // Generujemy losowe pozycje w obrêbie platformy
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

        // Uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            // Tworzymy obiekt
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            // Losujemy materia³
            Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(delay);
        }
    }
}