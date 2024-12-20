using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2f; 
    private bool isMoving = false; 
    private bool movingToB = true; 
    private int playerCount = 0;

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        Vector3 target = movingToB ? pointB.position : pointA.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            movingToB = !movingToB; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            playerCount++;
            isMoving = true; 
            other.transform.parent = transform; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount--;
            if (playerCount <= 0) 
            {
                isMoving = false;
            }
            other.transform.parent = null; 
        }
    }
}
