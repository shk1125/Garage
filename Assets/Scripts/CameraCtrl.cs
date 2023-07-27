using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float rotateSpeed;

    float xRotation;
    float yRotation;
    bool isDownMax;
    bool isUpMax;

    Transform placeHolderTransform;


    void Start()
    {
        placeHolderTransform = transform.parent;
        xRotation = 0;
        yRotation = 0;
    }


    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Rotate();

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Rotate()
    {
        xRotation = Input.GetAxis("Mouse Y");
        yRotation = Input.GetAxis("Mouse X");

       

        if (transform.eulerAngles.x >= 70.0f)
        {
            transform.position = new Vector3(transform.position.x, 2.1f, transform.position.z);
            transform.eulerAngles = new Vector3(69.9f, transform.eulerAngles.y, transform.eulerAngles.z);
            isDownMax = true;

        }
        else if (transform.eulerAngles.x <= 10.0f)
        {
            transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z);
            transform.eulerAngles = new Vector3(10.1f, transform.eulerAngles.y, transform.eulerAngles.z);
            isUpMax = true;
        }
        if (!isDownMax && !isUpMax)
        {
            transform.RotateAround(placeHolderTransform.position, transform.right, xRotation * rotateSpeed * -1.0f * Time.deltaTime);
        }

        transform.RotateAround(placeHolderTransform.position, Vector3.up, yRotation * rotateSpeed * Time.deltaTime);




        if (xRotation > 0)
        {
            isDownMax = false;
        }
        else if (xRotation < 0)
        {
            isUpMax = false;
        }


    }
}




