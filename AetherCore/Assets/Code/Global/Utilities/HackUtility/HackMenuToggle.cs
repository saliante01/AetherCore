using UnityEngine;

public class HackMenuToggle : MonoBehaviour
{
    public GameObject hackCanvas; // Asigna tu Canvas aquí en el inspector

    private int kPressCount = 0;
    private float pressTimer = 0f;
    public float pressWindow = 0.8f; // tiempo máximo entre K's (segundos)

    private void Start()
    {
        // Estado inicial seguro
        if (hackCanvas != null)
            hackCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Detectar triple K
        if (Input.GetKeyDown(KeyCode.K))
        {
            kPressCount++;
            pressTimer = 0f;

            if (kPressCount >= 3)
            {
                ToggleHackMenu(true);
                kPressCount = 0;
            }
        }

        // Resetear si pasa mucho tiempo entre las K
        if (kPressCount > 0)
        {
            pressTimer += Time.unscaledDeltaTime;
            if (pressTimer > pressWindow)
            {
                kPressCount = 0;
                pressTimer = 0f;
            }
        }

        // Cerrar con Escape
        if (hackCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleHackMenu(false);
        }
    }

    private void ToggleHackMenu(bool state)
    {
        hackCanvas.SetActive(state);

        if (state)
        {
            // Al abrir menú → desbloquear mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Al cerrar menú → volver a bloquear mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
