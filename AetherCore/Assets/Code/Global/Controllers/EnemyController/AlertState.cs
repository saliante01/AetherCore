using UnityEngine;

public class AlertState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} entra en ALERTA");

        // Llamar método específico del enemigo si existe
        if (enemy is EnemyA ea) ea.EnterAlert();
        else if (enemy is EnemyB eb) eb.EnterAlert();
    }

    public void UpdateState(Enemy enemy)
    {
        if (enemy.target == null) return;

        // Ejecutar ataque cada frame
        enemy.PerformAttack(enemy.target);
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} sale de ALERTA");
    }
}
