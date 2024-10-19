using UnityEngine;
 
public class CubeMover : MonoBehaviour
{
    public float speed = 20f; 
    private bool movingRight = true; 
    private float targetPositionX;
 
    void Start()
    {
        
        targetPositionX = transform.position.x + 10f;
    }
 
    void Update()
    {
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(targetPositionX, transform.position.y, transform.position.z), step);
 
        
        if (Vector3.Distance(transform.position, new Vector3(targetPositionX, transform.position.y, transform.position.z)) < 0.01f)
        {
            
            targetPositionX = movingRight ? transform.position.x - 10f : transform.position.x + 10f;
            movingRight = !movingRight;
        }
    }
}