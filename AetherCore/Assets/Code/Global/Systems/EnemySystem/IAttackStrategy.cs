using UnityEngine;

public interface IAttackStrategy
{
    // Ejecutar el ataque
    void ExecuteAttack(Enemy enemy, Transform target);
}

