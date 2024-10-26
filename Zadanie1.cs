using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Punkt startowy
    public Transform pointB; // Punkt docelowy
    public float speed = 2f; // Prêdkoœæ ruchu
    private bool isMoving = false; // Flaga ruchu
    private bool movingToB = true; // Kierunek ruchu

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

        // Sprawdzenie, czy platforma dotar³a do punktu docelowego
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            movingToB = !movingToB; // Zmiana kierunku
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdzanie, czy obiekt to gracz
        {
            isMoving = true; // Rozpoczêcie ruchu
            other.transform.parent = transform; // Ustawienie gracza jako dziecka platformy
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null; // Zdejmowanie gracza z platformy
        }
    }
}