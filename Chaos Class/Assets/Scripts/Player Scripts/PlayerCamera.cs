using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    //private Vector3 initialPosition;
    //private Quaternion initialRotation;


    public Transform orientation;
    public GameObject hands;

    float xRotation;
    float yRotation;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //initialPosition = transform.position;
        //initialRotation = transform.rotation;

    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    

//public void ResetCamera()
//{
//    //transform.position = initialPosition;
//    xRotation = 0;
//    yRotation = 0;
//}


}
