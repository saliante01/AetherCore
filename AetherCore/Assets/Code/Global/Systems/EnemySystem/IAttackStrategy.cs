using UnityEngine;

public interface IAttackStrategy
{
    // Ejecutar el ataque
    void ExecuteAttack(Enemy enemy, Transform target);
    bool IsActive { get; }  // Indica si el ataque está activo
    void StopAttack();
}

