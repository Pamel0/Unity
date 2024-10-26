using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public GameObject player; // Mo¿na przypisaæ w inspektorze lub znaleŸæ dynamicznie
    public float openDistance = 3f;
    public float slideSpeed = 2f;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Zmiana, aby znaleŸæ gracza dynamicznie
        closedPosition = transform.position;
        openPosition = closedPosition + new Vector3(2.3f, 0f, 0f);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < openDistance)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, slideSpeed * Time.deltaTime);
            if (transform.position == openPosition)
            {
                isOpen = true;
            }
        }
    }

    void CloseDoor()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, slideSpeed * Time.deltaTime);
            if (transform.position == closedPosition)
            {
                isOpen = false;
            }
        }
    }
}
