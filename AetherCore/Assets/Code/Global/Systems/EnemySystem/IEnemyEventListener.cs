using UnityEngine;

public interface IEnemyEventListener
{
    // Método para reaccionar a eventos externos
    void OnEnemyEvent(EnemyEvent enemyEvent);
}

