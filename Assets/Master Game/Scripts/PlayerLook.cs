//If you're not using these, they can be removed.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We should have a namespace with the name of game in there. This is very useful to keep track of what we made, and prevents same-name issues with asset packages we use.

//PlayerLook is not the greatest class name ever, maybe think about a clearer name?
public class PlayerLook : MonoBehaviour
{
    //Why do these exist? These are constants from Unity itself.
    [SerializeField] private string mouseXInputName, mouseYInputName;

    //This is really good variable naming. Correct casing, clear names. Very well done.
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    //Good thinking.
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    //Always make method names a command. That makes code more readable.
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //This is a good method name. It's clear what it does, and is a command.
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}
