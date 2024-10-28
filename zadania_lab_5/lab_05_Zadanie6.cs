using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Rozpoczeto kontakt z przeszkoda!");
        }
    }
}
