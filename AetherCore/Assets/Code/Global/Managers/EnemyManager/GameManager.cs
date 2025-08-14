using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs de enemigos")]
    public EnemyA enemyAPrefab;
    public EnemyB enemyBPrefab;

    [Header("Configuración de la escena")]
    public Transform[] patrolPointsA; // Puntos de patrulla para EnemyA
    public Transform[] patrolPointsB; // Puntos de patrulla para EnemyB
    public Transform player;

    private void Start()
    {
        // --- Instanciar EnemyA ---
        EnemyA enemyA = Instantiate(enemyAPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemyA.patrolPoints = patrolPointsA;   // Asignar puntos de patrulla
        enemyA.Initialize(player);             // Inicializar el enemigo

        // --- Instanciar EnemyB ---
        EnemyB enemyB = Instantiate(enemyBPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        enemyB.patrolPoints = patrolPointsB;   // Asignar puntos de patrulla
        enemyB.Initialize(player);             // Inicializar el enemigo
    }
}
