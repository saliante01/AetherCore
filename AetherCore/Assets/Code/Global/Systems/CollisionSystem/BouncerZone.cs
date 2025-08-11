using UnityEngine;
using Unity.Mathematics; // Asegúrate de tener esto si usas float3

/// <summary>
/// Esta clase representa una zona de rebote en el juego.
/// Este componente aplica una fuerza hacia arriba al jugador cuando entra en contacto con la zona.
/// Además, permite que la zona se mueva de arriba hacia abajo con una velocidad configurable.
/// </summary>
[RequireComponent(typeof(Collider))]
public class BouncerZone : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f; // Fuerza de rebote configurable aplicada al jugador
    [SerializeField] private float moveSpeed = 2f;    // Velocidad de movimiento vertical de la zona
    [SerializeField] private float moveDistance = 3f; // Distancia máxima de movimiento desde la posición inicial

    private Vector3 initialPosition; // Guarda la posición inicial para calcular el movimiento
    private bool movingDown = true;  // Indica si la zona se está moviendo hacia abajo

    /// <summary>
    /// Inicializa la posición inicial de la zona de rebote.
    /// </summary>
    private void Start()
    {
        // Guarda la posición inicial para calcular el movimiento
        initialPosition = transform.position;
    }

    /// <summary>
    /// Método llamado cuando el componente se resetea o se añade en el editor.
    /// Se asegura de que el collider NO sea un trigger, para usar colisiones físicas.
    /// </summary>
    private void Reset()
    {
        GetComponent<Collider>().isTrigger = false;
    }

    /// <summary>
    /// Llama al método que mueve la zona de rebote cada frame.
    /// </summary>
    private void Update()
    {
        MoveZone();
    }

    /// <summary>
    /// Mueve la zona de rebote de arriba hacia abajo entre dos puntos, 
    /// con velocidad y distancia configurables desde el inspector.
    /// </summary>
    private void MoveZone()
    {
        float delta = moveSpeed * Time.deltaTime;
        if (movingDown)
        {
            transform.position += Vector3.down * delta;
            if (transform.position.y <= initialPosition.y - moveDistance)
                movingDown = false;
        }
        else
        {
            transform.position += Vector3.up * delta;
            if (transform.position.y >= initialPosition.y)
                movingDown = true;
        }
    }

    /// <summary>
    /// Detecta cuando un objeto colisiona con la zona de rebote.
    /// Si el objeto tiene el tag "Player", aplica una fuerza hacia arriba y muestra un mensaje en consola.
    /// </summary>
    /// <param name="collision">La colisión que entra en la zona.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El jugador ha colisionado con la zona de rebote.");

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Establece la velocidad vertical directamente para un rebote fijo
                rb.linearVelocity = new float3(rb.linearVelocity.x, bounceForce, rb.linearVelocity.z);
            }
        }
    }
}
