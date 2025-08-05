using UnityEngine;

/// <summary>
/// Esta clase representa una zona de pared en el juego.
/// Este componente detecta cuando el jugador colisiona con la zona y muestra un mensaje en consola.
/// </summary>
[RequireComponent(typeof(Collider))]
public class WallZone : MonoBehaviour
{
    /// <summary>
    /// Método llamado cuando el componente se resetea o se añade en el editor.
    /// Se asegura de que el collider NO sea un trigger, para usar colisiones físicas.
    /// </summary>
    private void Reset()
    {
        GetComponent<Collider>().isTrigger = false;
    }

    /// <summary>
    /// Detecta cuando un objeto colisiona con la zona de pared.
    /// Si el objeto tiene el tag "Player", muestra un mensaje en consola.
    /// </summary>
    /// <param name="collision">La colisión que entra en la zona.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El jugador ha colisionado con la zona de pared.");
        }
    }
}