using UnityEngine;

public interface IAttackStrategy
{
    // Ejecuta el ataque
    void ExecuteAttack(Enemy enemy, Transform target);
}

