using UnityEngine;

/// <summary>
/// Esta clase representa una zona de rebote en el juego.
/// Este componente aplica una fuerza hacia arriba al jugador cuando entra en contacto con la zona.
/// </summary>
[RequireComponent(typeof(Collider))]
public class BouncerZone : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f; // Fuerza de rebote configurable

    /// <summary>
    /// Método llamado cuando el componente se resetea o se añade en el editor.
    /// Se asegura de que el collider NO sea un trigger, para usar colisiones físicas.
    /// </summary>
    private void Reset()
    {
        GetComponent<Collider>().isTrigger = false;
    }

    /// <summary>
    /// Detecta cuando un objeto colisiona con la zona de rebote.
    /// Si el objeto tiene el tag "Player", aplica una fuerza hacia arriba.
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
                // Reinicia la velocidad vertical antes de aplicar la fuerza de rebote
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * bounceForce, ForceMode.VelocityChange);
            }
        }
    }
}
