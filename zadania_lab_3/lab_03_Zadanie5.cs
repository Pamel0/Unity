using UnityEngine;
using System.Collections.Generic;

public class Zadanie5 : MonoBehaviour
{
    public GameObject cubePrefab; 
    public int numberOfCubes = 10; 
    public float planeSize = 5f; 

    private HashSet<Vector3> positions = new HashSet<Vector3>(); 

    void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position;

        do
        {
            position = new Vector3(Random.Range(-planeSize, planeSize), 0.5f, Random.Range(-planeSize, planeSize));
        } while (positions.Contains(position)); 

        positions.Add(position); 

        return position;
    }
}
