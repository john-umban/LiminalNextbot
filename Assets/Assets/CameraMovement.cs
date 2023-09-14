using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerBody;
    public Transform cameraHolder;

    public float sens;

    public float currentY;
    
    public void Start(){
        
        currentY = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
        {
            float inputX = Input.GetAxisRaw("Mouse X");
            float inputY = Input.GetAxisRaw("Mouse Y");

            currentY -= inputY;
            currentY = Mathf.Clamp(currentY, -90f, 90f);


            playerBody.Rotate(new Vector3(0, inputX * Time.deltaTime * sens));

            cameraHolder.localRotation = Quaternion.Euler(currentY, 0f, 0f);

            playerBody.Rotate(Vector3.up * inputX);

        }
}