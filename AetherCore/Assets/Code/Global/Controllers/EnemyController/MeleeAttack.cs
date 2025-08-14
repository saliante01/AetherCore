using UnityEngine;

public class MeleeAttack : IAttackStrategy
{
    public void ExecuteAttack(Enemy enemy, Transform target)
    {
        Debug.Log($"{enemy.name} realiza un ataque cuerpo a cuerpo contra {target.name}");
        // Aquí iría la lógica de daño, animaciones, etc.
    }
}
