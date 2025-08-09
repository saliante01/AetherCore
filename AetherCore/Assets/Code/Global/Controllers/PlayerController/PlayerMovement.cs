using UnityEngine;

/// <summary>
/// Controla el movimiento del jugador en un entorno 3D, incluyendo caminar, correr, salto
/// y rotación basada en la dirección de la cámara.
/// Incluye "coyote time" y "jump buffer" para saltos más responsivos.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float walkSpeed = 1.5f;         // Velocidad al caminar
    [SerializeField] private float runMultiplier = 2f;       // Multiplicador de velocidad al correr

    [Header("Salto")]
    [SerializeField] private float jumpForce = 3f;           // Fuerza del salto
    [SerializeField] private float coyoteTime = 0.15f;       // Tiempo de gracia para saltar tras dejar el suelo
    [SerializeField] private float jumpBufferTime = 0.1f;    // Tiempo de gracia para detectar salto antes de tocar el suelo

    [Header("Cámara")]
    [SerializeField] private CameraController cameraController;  // Referencia al controlador de cámara

    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isGrounded;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    private bool jumpReleased = true; // Evita múltiples saltos mientras mantienes la tecla

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (cameraController == null)
        {
            Debug.LogError("Asigna el CameraController en el inspector.");
            enabled = false;
        }
    }

    private void Update()
    {
        HandleMovementInput();
        HandleRotation();
        HandleCoyoteTime();
        HandleJumpBuffer();
        HandleJump();

        // Detectar cuando se suelta la tecla de salto
        if (Input.GetButtonUp("Jump"))
            jumpReleased = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // -------------------------------
    // MOVIMIENTO
    // -------------------------------
    private void HandleMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraController.GetCameraForward();
        Vector3 right = cameraController.GetCameraRight();

        moveDirection = (right * x + forward * z).normalized;
    }

    private void HandleRotation()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }
    }

    private void MovePlayer()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? walkSpeed * runMultiplier : walkSpeed;
        Vector3 velocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
        rb.linearVelocity = velocity;
    }

    // -------------------------------
    // SALTO
    // -------------------------------
    private void HandleCoyoteTime()
    {
        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }

    private void HandleJumpBuffer()
    {
        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;
    }

    private void HandleJump()
    {
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f && jumpReleased)
        {
            // Reinicia velocidad vertical para que el salto sea inmediato
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
            jumpReleased = false; // Bloquea hasta que se suelte la tecla
        }
    }

    // -------------------------------
    // DETECCIÓN DE SUELO
    // -------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
            isGrounded = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
            isGrounded = false;
    }
}
