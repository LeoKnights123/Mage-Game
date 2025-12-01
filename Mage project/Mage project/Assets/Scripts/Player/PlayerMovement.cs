using UnityEngine;


public class PlayerMovementCC : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpForce = 4f;

    CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // horizontal input
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        // ensure a small downward force when grounded
        if (characterController.isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // jump input
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // apply gravity
        velocity.y += gravity * Time.deltaTime;

        // combine horizontal and vertical and call Move once
        Vector3 finalMove = move * speed + new Vector3(0f, velocity.y, 0f);
        characterController.Move(finalMove * Time.deltaTime);
    }
}
