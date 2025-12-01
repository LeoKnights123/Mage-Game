using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float sensetivity = 400f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * MouseX);
    }
}
