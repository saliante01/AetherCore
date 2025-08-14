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

        // Seguir al jugador
        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            enemy.target.position,
            enemy.speed * Time.deltaTime
        );

        // Atacar si está cerca
        float distance = Vector3.Distance(enemy.transform.position, enemy.target.position);
        if (distance < 1.5f) // rango de ataque
        {
            enemy.PerformAttack(enemy.target);
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} sale del estado de alerta");
    }
}
