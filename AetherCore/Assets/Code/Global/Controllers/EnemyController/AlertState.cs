using UnityEngine;

public class AlertState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} entra en estado de alerta");
    }

    public void UpdateState(Enemy enemy)
    {
        if (enemy.target == null) return;

        // Mantener altura constante
        Vector3 targetPosition = new Vector3(
            enemy.target.position.x,
            enemy.transform.position.y,
            enemy.target.position.z
        );

        // Mover hacia el jugador al doble de velocidad
        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            targetPosition,
            (enemy.speed * 2) * Time.deltaTime
        );

        // Atacar si está cerca
        float distance = Vector3.Distance(enemy.transform.position, targetPosition);
        if (distance < 1.5f)
        {
            enemy.PerformAttack(enemy.target);
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} sale del estado de alerta");
    }
}
