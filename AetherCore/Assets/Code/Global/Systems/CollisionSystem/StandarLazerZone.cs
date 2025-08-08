using UnityEngine;
using System.Collections;

public class StandarLazerZone : MonoBehaviour
{
    [Header("Laser Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Laser Settings")]
    public float laserWidth = 0.1f;
    public float activationSpeed = 10f; // units per second
    public float deactivationTime = 2f;
    public float activeTime = 3f;
    public LayerMask playerLayer;

    [Header("Damage Settings")]
    public float damageInterval = 0.5f; // tiempo entre daños al jugador

    private LineRenderer lineRenderer;
    private bool isActive = true;
    private float currentLength = 0f;
    private float maxLength = 0f;
    private float lastDamageTime = -999f;
    private float raycastInterval = 0.05f; // cada cuánto tiempo lanzamos raycast
    private float lastRaycastTime = 0f;

    void Awake()
    {
        SetupLineRenderer();
    }

    void OnEnable()
    {
        InitializeLaserLength();
        StartCoroutine(LaserRoutine());
    }

    private void SetupLineRenderer()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.enabled = false; // inicia apagado
    }

    private void InitializeLaserLength()
    {
        if (pointA != null && pointB != null)
        {
            maxLength = Vector3.Distance(pointA.position, pointB.position);
        }
    }

    private IEnumerator LaserRoutine()
    {
        while (true)
        {
            ActivateLaser();
            yield return StartCoroutine(ExtendLaser());
            yield return StartCoroutine(KeepLaserActive());
            yield return StartCoroutine(DeactivateLaser());
        }
    }

    private void ActivateLaser()
    {
        isActive = true;
        currentLength = 0f;
        lineRenderer.enabled = true;
        UpdateLaser(true); // fuerza actualización
    }

    private IEnumerator ExtendLaser()
    {
        while (currentLength < maxLength)
        {
            currentLength += activationSpeed * Time.deltaTime;
            currentLength = Mathf.Min(currentLength, maxLength);
            UpdateLaser(true); // siempre actualiza en extensión
            TryRaycast();
            yield return null;
        }
    }

    private IEnumerator KeepLaserActive()
    {
        float timer = 0f;
        while (timer < activeTime)
        {
            // Solo raycast a intervalos
            TryRaycast();

            // Solo actualizar si los puntos se mueven (optimizable si son estáticos)
            UpdateLaser(false);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator DeactivateLaser()
    {
        isActive = false;
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(deactivationTime);
    }

    private void UpdateLaser(bool forceUpdate)
    {
        if (pointA == null || pointB == null) return;

        // Si no forzamos y los puntos no se mueven, no actualizamos
        if (!forceUpdate && currentLength >= maxLength) return;

        Vector3 dir = (pointB.position - pointA.position).normalized;
        Vector3 endPos = pointA.position + dir * currentLength;
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, endPos);
    }

    private void TryRaycast()
    {
        if (!isActive) return;

        // Solo raycast si ha pasado el intervalo
        if (Time.time - lastRaycastTime < raycastInterval) return;
        lastRaycastTime = Time.time;

        Vector3 dir = (pointB.position - pointA.position).normalized;
        if (Physics.Raycast(pointA.position, dir, out RaycastHit hit, currentLength, playerLayer))
        {
            // Cooldown de daño
            if (Time.time - lastDamageTime >= damageInterval)
            {
                lastDamageTime = Time.time;
                Debug.Log("Se ha hecho daño al jugador");
                // Aquí iría la lógica real de daño
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}
