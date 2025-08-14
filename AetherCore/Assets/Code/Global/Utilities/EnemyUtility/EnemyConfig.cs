using UnityEngine;

// Clase serializable para configurar enemigos
[System.Serializable]
public class EnemyConfig
{
    [Header("Prefab del enemigo")]
    public Enemy enemyPrefab;

    [Header("Puntos de patrulla (opcional)")]
    public Transform[] patrolPoints;

    [Header("Estado inicial")]
    public IEnemyState initialState;

    [Header("Ataque inicial")]
    public IAttackStrategy attackStrategy;
}