using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] int jumpCount = 0;

    [SerializeField] AudioSource jumpSound;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] float mouseSensetivity = 0.15f;
    InputAction lookAction;

    [SerializeField] Transform cameraTransform;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private float pitch = 0f;
    void Start()
    {
        Debug.Log("PlayerMovement script has started.");
        rb = GetComponent<Rigidbody>();

        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector3(horizontalInput * movementSpeed, rb.linearVelocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            Jump();
        }

        if (IsGrounded())
        {
            jumpCount = 0;
        }

        float mouseX = lookAction.ReadValue<Vector2>().x * mouseSensetivity;
        float mouseY = lookAction.ReadValue<Vector2>().y * mouseSensetivity;
        transform.Rotate(0f, mouseX, 0f);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minX, maxX);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        Vector3 move = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * movementSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        jumpSound.Play();
        jumpCount = jumpCount +1;
        Debug.Log("Jump count: " + jumpCount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}