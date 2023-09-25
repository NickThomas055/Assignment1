using UnityEngine;

public class Looking : MonoBehaviour
{
    public float sensitivity = 2.0f; 
    public Transform playerBody; 

    private float verticalRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player's body horizontally based on mouse movement
        transform.GetComponent<Rigidbody>().AddRelativeTorque(0,mouseX * sensitivity,0);
        //transform.Rotate(0,mouseX * sensitivity,0);

        // Rotate the camera vertically based on mouse movement
        //verticalRotation -= mouseY;
        //verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Clamp vertical rotation to avoid flipping

        // Apply vertical rotation to the camera or GameObject
        //transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
   
        
    }
}