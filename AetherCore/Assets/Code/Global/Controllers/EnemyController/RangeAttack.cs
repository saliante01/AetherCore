using UnityEngine;

public class RangeAttack : IAttackStrategy
{
    public bool IsActive { get; private set; }
    private LineRenderer lineRenderer;
    private float lineDuration = 0.5f;
    private float lineTimer = 0f;

    public void ExecuteAttack(Enemy enemy, Transform target)
    {
        if (target == null) return;

        IsActive = true;

        // Lógica de ataque (solo debug por ahora)
        Debug.Log($"{enemy.name} realiza ataque a distancia al jugador");

        // Asegura que el enemigo tenga un LineRenderer
        if (lineRenderer == null)
        {
            lineRenderer = enemy.GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                lineRenderer = enemy.gameObject.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startWidth = 0.05f;
                lineRenderer.endWidth = 0.05f;
                lineRenderer.positionCount = 2;
                lineRenderer.startColor = new Color(0.5f, 0, 0.5f); // Morado
                lineRenderer.endColor = new Color(0.5f, 0, 0.5f);
            }
        }

        // Dibuja la línea morada desde el enemigo hacia el objetivo
        Vector3 origin = enemy.transform.position;
        Vector3 targetPos = target.position;
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, targetPos);
        lineRenderer.enabled = true;
        lineTimer = lineDuration;
    }

    public void StopAttack()
    {
        IsActive = false;
        if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
            // Limpia las posiciones para evitar residuos visuales
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }

    // Llama este método desde Update del Enemy para ocultar la línea tras un tiempo
    public void UpdateLine()
    {
        if (lineRenderer != null && lineRenderer.enabled)
        {
            lineTimer -= Time.deltaTime;
            if (lineTimer <= 0f)
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
