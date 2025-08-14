using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Configuración de Enemigos")]
    public Enemy enemyPrefab;
    public Transform[] patrolPoints;
    public Transform player;

    public GameObject projectilePrefab;

    private void Start()
    {
        // Crear un enemigo de ejemplo
        Enemy enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        // Estado inicial: patrulla
        PatrolState patrolState = new PatrolState(patrolPoints);
        enemy.ChangeState(patrolState);

        // Estrategia de ataque inicial: melee
        MeleeAttack meleeAttack = new MeleeAttack();
        enemy.SetAttackStrategy(meleeAttack);

        // Configurar target
        enemy.target = player;

        // Simular cambio a ataque a distancia después de 5 segundos
        Invoke(nameof(ChangeToRangeAttack), 5f);

        void ChangeToRangeAttack()
        {
            RangeAttack rangeAttack = new RangeAttack();
            rangeAttack.projectilePrefab = projectilePrefab;
            rangeAttack.projectileSpeed = 12f;
            enemy.SetAttackStrategy(rangeAttack);

            // Cambiar a alerta
            AlertState alertState = new AlertState();
            enemy.ChangeState(alertState);

            // Disparar evento de detección del jugador
            EventManager.TriggerEvent(new EnemyEvent("PlayerDetected", player.position));
        }
    }
}
