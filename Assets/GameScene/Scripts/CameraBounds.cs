using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float padding = 1f;

    private Camera mainCamera;
    private float leftBound, rightBound, bottomBound, topBound;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // Calculate the camera bounds based on the screen size and camera position, with padding
        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(padding, padding, 0f));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - padding, Screen.height - padding - 200f, 0f));
        leftBound = bottomLeft.x;
        rightBound = topRight.x;
        bottomBound = bottomLeft.y;
        topBound = topRight.y;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Clamp the player's position to the camera bounds
        float clampedX = Mathf.Clamp(transform.position.x, leftBound, rightBound);
        float clampedY = Mathf.Clamp(transform.position.y, bottomBound, topBound);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
