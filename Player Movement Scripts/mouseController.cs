using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to the camera used for the player assest

public class mouseController : MonoBehaviour
{
    public float mouseSense = 100f; //sensitivity

    public Transform player;

    float xRotate;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
       
        player.Rotate(Vector3.up * mouseX);
    }
}
