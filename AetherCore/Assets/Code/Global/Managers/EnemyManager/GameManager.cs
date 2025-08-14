using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Configuración de Enemigos")]
    public Enemy enemyPrefab;
    public Transform[] patrolPoints;
    public Transform player;
    public GameObject projectilePrefab;

    private Enemy enemyInstance;

    private void Start()
    {
        // Crear un enemigo
        enemyInstance = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);

        // Estado inicial: patrulla
        PatrolState patrolState = new PatrolState(patrolPoints);
        enemyInstance.ChangeState(patrolState);

        // Estrategia de ataque inicial: melee
        MeleeAttack meleeAttack = new MeleeAttack();
        enemyInstance.SetAttackStrategy(meleeAttack);

        // Configurar target
        enemyInstance.target = player;

        // Programar el cambio
        Invoke(nameof(ChangeToRangeAttack), 5f);
    }

    private void ChangeToRangeAttack()
    {
        RangeAttack rangeAttack = new RangeAttack();
        rangeAttack.projectilePrefab = projectilePrefab;
        rangeAttack.projectileSpeed = 12f;
        enemyInstance.SetAttackStrategy(rangeAttack);

        // Cambiar a alerta
        AlertState alertState = new AlertState();
        enemyInstance.ChangeState(alertState);

        // Disparar evento de detección
        EventManager.TriggerEvent(new EnemyEvent("PlayerDetected", player.position));
    }
}
