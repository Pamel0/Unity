using UnityEngine;
using System.Collections.Generic;

public class Zadanie5 : MonoBehaviour
{
    public GameObject cubePrefab; // Prefabrykat Cube
    public int numberOfCubes = 10; // Liczba generowanych kostek
    public float planeSize = 5f; // Rozmiar płaszczyzny

    private HashSet<Vector3> positions = new HashSet<Vector3>(); // Zestaw pozycji

    void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            // Tworzenie kostki na wylosowanej pozycji
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position;

        do
        {
            // Losowa pozycja w granicach płaszczyzny
            position = new Vector3(Random.Range(-planeSize, planeSize), 0.5f, Random.Range(-planeSize, planeSize));
        } while (positions.Contains(position)); // Sprawdzenie, czy pozycja już istnieje

        positions.Add(position); // Dodanie pozycji do zestawu

        return position;
    }
}
