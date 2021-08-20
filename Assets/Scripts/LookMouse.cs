using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject menuManagerObj;
    bool isLocked;
    // Start is called before the first frame update
    void Start()
    {
        bool canStartLook = menuManagerObj.GetComponent<MenuManagerScript>().canMouseInput;
        isLocked = true;
        Debug.Log("Screen Height : " + Screen.height);
        Debug.Log("Screen width : " + Screen.width);
        if (!isLocked && Input.GetMouseButtonDown(0))
        {
            lockCursor();
        }
    }
    public void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLocked = true;
    }
    public void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true ;
        isLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLocked)
                unlockCursor();
        }
        
        bool canStartLook = menuManagerObj.GetComponent<MenuManagerScript>().canMouseInput;
        if (canStartLook)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            playerBody.Rotate(Vector3.up * mouseX);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        
    }
}
