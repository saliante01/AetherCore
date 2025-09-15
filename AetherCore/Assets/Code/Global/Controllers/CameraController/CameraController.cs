using UnityEngine;

/// <summary>
/// Controla la cámara para que siga al jugador con movimiento suave y rotación
/// basada en la entrada del mouse, limitando los ángulos verticales.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;           // Referencia al transform del jugador
    public Transform cameraTarget;     // Punto objetivo que la cámara sigue (usualmente un empty encima del jugador)

    [Header("Sensibilidad y suavizado")]
    public float mouseSensitivity = 4f;        // Sensibilidad del mouse
    public float rotationSmoothTime = 0.1f;    // Tiempo de suavizado de la rotación

    [Header("Límites verticales")]
    public float minVerticalAngle = -20f;      // Ángulo mínimo de rotación vertical
    public float maxVerticalAngle = 40f;       // Ángulo máximo de rotación vertical

    private Vector3 offset;                    // Distancia inicial entre la cámara y el objetivo
    private float yaw = 0f;                    // Rotación horizontal acumulada
    private float pitch = 10f;                 // Rotación vertical acumulada

    private Vector3 currentRotation;           // Rotación actual interpolada
    private Vector3 rotationSmoothVelocity;    // Velocidad usada para suavizar la rotación

    private void Start()
    {
        InicializarCamara();
    }

    private void LateUpdate()
    {
        ProcesarEntradaMouse();
        AplicarRotacionSuavizada();
        PosicionarCamara();
        ApuntarHaciaTarget();
    }

    /// <summary>
    /// Inicializa la cámara, bloquea el cursor y calcula el offset inicial.
    /// </summary>
    private void InicializarCamara()
    {
       // Cursor.lockState = CursorLockMode.Locked; Ahora lo maneja el HackMenuToggle

        if (player == null || cameraTarget == null)
        {
            Debug.LogError("Asigna Player y CameraTarget en el inspector");
            enabled = false;
            return;
        }

        offset = transform.position - cameraTarget.position;

        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    /// <summary>
    /// Captura la entrada del mouse y ajusta yaw y pitch.
    /// </summary>
    private void ProcesarEntradaMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;

        // Limita la rotación vertical
        pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);
    }

    /// <summary>
    /// Calcula la rotación interpolada suavemente para aplicar a la cámara.
    /// </summary>
    private void AplicarRotacionSuavizada()
    {
        Vector3 targetRotation = new Vector3(pitch, yaw);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);
    }

    /// <summary>
    /// Posiciona la cámara basada en la rotación interpolada y el offset.
    /// </summary>
    private void PosicionarCamara()
    {
        Quaternion rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        Vector3 desiredPosition = cameraTarget.position + rotation * offset;
        transform.position = desiredPosition;
    }

    /// <summary>
    /// Hace que la cámara siempre apunte al target.
    /// </summary>
    private void ApuntarHaciaTarget()
    {
        transform.rotation = Quaternion.LookRotation(cameraTarget.position - transform.position);
    }

    /// <summary>
    /// Devuelve la rotación horizontal actual de la cámara (yaw).
    /// </summary>
    public float GetCameraYaw()
    {
        return currentRotation.y;
    }

    /// <summary>
    /// Devuelve el vector forward de la cámara proyectado en el plano XZ (sin componente vertical).
    /// </summary>
    public Vector3 GetCameraForward()
    {
        Vector3 forward = transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

    /// <summary>
    /// Devuelve el vector right de la cámara proyectado en el plano XZ (sin componente vertical).
    /// </summary>
    public Vector3 GetCameraRight()
    {
        Vector3 right = transform.right;
        right.y = 0f;
        return right.normalized;
    }
}