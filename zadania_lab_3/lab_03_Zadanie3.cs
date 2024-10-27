using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float speed = 2f; 
    public float size = 5f; 
    private Vector3[] corners;
    private int currentCorner = 0;

    void Start()
    {
        UpdateCorners();
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
            currentCorner = (currentCorner + 1) % corners.Length; 
        }
    }

    void UpdateCorners()
    {
        corners = new Vector3[4];
        Vector3 startPosition = transform.position; 

        corners[0] = startPosition + new Vector3(size, 0, 0);    
        corners[1] = corners[0] + new Vector3(0, 0, -size);       
        corners[2] = corners[1] + new Vector3(-size, 0, 0);     
        corners[3] = corners[2] + new Vector3(0, 0, size);       
    }
}
