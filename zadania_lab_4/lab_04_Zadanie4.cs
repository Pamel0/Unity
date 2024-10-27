using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;
    public float smoothTime = 0.1f; // Czas wygładzania
    private float rotationY = 0f; // Zmienna do przechowywania kąta X
    private float rotationX = 0f; // Zmienna do przechowywania kąta Y
    private float xVelocity = 0f; // Zmienna do wygładzania X
    private float yVelocity = 0f; // Zmienna do wygładzania Y

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX += mouseXMove;
        rotationY -= mouseYMove;

        // Ograniczamy kąt rotacji w osi Y (X)
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        float targetRotationX = Mathf.SmoothDampAngle(player.eulerAngles.y, rotationX, ref xVelocity, smoothTime);
        float targetRotationY = Mathf.SmoothDampAngle(transform.eulerAngles.x, rotationY, ref yVelocity, smoothTime);

        player.rotation = Quaternion.Euler(0f, targetRotationX, 0f);
        transform.localRotation = Quaternion.Euler(targetRotationY, 0f, 0f);
    }
}
