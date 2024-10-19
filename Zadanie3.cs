using UnityEngine;
 
public class Zadanie3 : MonoBehaviour
{
    public float speed = 2f; // Prędkość ruchu
    private Vector3[] corners;
    private int currentCorner = 0;
 
    void Start()
    {
        corners = new Vector3[4];
        corners[0] = new Vector3(5, 0, 5);
        corners[1] = new Vector3(-5, 0, 5);
        corners[2] = new Vector3(-5, 0, -5);
        corners[3] = new Vector3(5, 0, -5);
    }
 
    void Update()
    {
        MoveTowardsCorner();
    }
 
    void MoveTowardsCorner()
    {
        transform.position = Vector3.MoveTowards(transform.position, corners[currentCorner], speed * Time.deltaTime);
 
        if (Vector3.Distance(transform.position, corners[currentCorner]) < 0.1f)
        {
            transform.Rotate(0, 90, 0);
            currentCorner = (currentCorner + 1) % corners.Length; // Przechodzenie do następnego wierzchołka
        }
    }
}
