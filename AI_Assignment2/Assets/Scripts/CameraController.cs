using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quinn Daggett - 100618734
// 2020-01-29

public class CameraController : MonoBehaviour
{
    float rotationX;
    float rotationY;
    private float lookSensitivity = 4.0f;
    Transform player;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.setup)
        {
            // Get rotation input from mouse
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
            rotationY += Input.GetAxis("Mouse Y") * lookSensitivity;

            // Prevent player from rolling the camera upside down/into themselves
            rotationY = Mathf.Clamp(rotationY, -80f, 80f);

            // Rotate camera on Y axis
            transform.localRotation = Quaternion.AngleAxis(-rotationY, Vector3.right);

            // Rotate player capsule (camera is child of player) on X axis
            player.localRotation = Quaternion.AngleAxis(rotationX, player.transform.up);
        }
        
    }
}
