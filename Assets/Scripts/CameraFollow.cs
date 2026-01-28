using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float Xrotation;
    float ClampRotation = 90;
    public bool MouseActive;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
      if (Input.GetMouseButtonDown(0))
        {          
            MouseActive = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && MouseActive == true)
        {
            Cursor.lockState = CursorLockMode.None;
            MouseActive = false;
             
        }

        if (MouseActive == true)
        {
            float Mousex =( Input.GetAxis("Mouse X") * mouseSensitivity )* Time.deltaTime;
            float MouseY = (Input.GetAxis("Mouse Y") * mouseSensitivity )* Time.deltaTime;

            Xrotation -= MouseY;

            Xrotation = Mathf.Clamp(Xrotation, -ClampRotation, ClampRotation);

            transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
            playerBody.transform.Rotate(Vector3.up * Mousex);
        }
        


    }
}

