using UnityEngine;

/// <summary>
/// Controla el movimiento del jugador en un entorno 3D, incluyendo caminar, correr, salto
/// y rotación basada en la dirección de la cámara.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float walkSpeed = 1.5f;         // Velocidad al caminar
    [SerializeField] private float runMultiplier = 2f;       // Multiplicador de velocidad al correr

    [Header("Salto")]
    [SerializeField] private float jumpForce = 3f;           // Fuerza del salto

    [Header("Cámara")]
    [SerializeField] private CameraController cameraController;  // Referencia al controlador de cámara

    private Rigidbody rb;                    // Rigidbody del jugador
    private Vector3 moveDirection;           // Dirección de movimiento calculada
    private bool isGrounded;                 // Indica si el jugador está tocando el suelo

    /// <summary>
    /// Inicializa las referencias necesarias al iniciar el juego.
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (cameraController == null)
        {
            Debug.LogError("Asigna el CameraController en el inspector.");
            enabled = false;
        }
    }

    /// <summary>
    /// Lógica de entrada del jugador (movimiento, salto, rotación).
    /// </summary>
    private void Update()
    {
        HandleMovementInput();  // Detectar teclas de movimiento
        HandleRotation();       // Rotar jugador según dirección
        HandleJump();           // Detectar salto
    }

    /// <summary>
    /// Lógica de movimiento que afecta al Rigidbody (física).
    /// </summary>
    private void FixedUpdate()
    {
        MovePlayer();           // Aplicar movimiento al Rigidbody
    }

    // -------------------------------
    // MÉTODOS ORGANIZADOS POR FUNCIÓN
    // -------------------------------

    /// <summary>
    /// Captura la entrada del teclado para moverse en base a la cámara.
    /// </summary>
    private void HandleMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Obtener los vectores de dirección según la orientación de la cámara
        Vector3 forward = cameraController.GetCameraForward();
        Vector3 right = cameraController.GetCameraRight();

        // Combinar direcciones para obtener la dirección final de movimiento
        moveDirection = (right * x + forward * z).normalized;
    }

    /// <summary>
    /// Rota al jugador suavemente en la dirección del movimiento.
    /// </summary>
    private void HandleRotation()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }
    }

    /// <summary>
    /// Aplica salto si el jugador está en el suelo.
    /// </summary>
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Aplica velocidad al Rigidbody en la dirección deseada.
    /// </summary>
    private void MovePlayer()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? walkSpeed * runMultiplier : walkSpeed;
        Vector3 velocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
        rb.linearVelocity = velocity;
    }

    // -------------------------------
    // DETECCIÓN DE SUELO
    // -------------------------------

    /// <summary>
    /// Detecta cuándo el jugador está tocando el suelo.
    /// </summary>
    /// <param name="collision">Colisión detectada.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
        }
    }

    /// <summary>
    /// Detecta cuándo el jugador deja de tocar el suelo.
    /// </summary>
    /// <param name="collision">Colisión detectada.</param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = false;
        }
    }
}