using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyEventListener
{
    [Header("Configuración")]
    public float speed = 2f;
    public Transform target; // Usado en estados de alerta

    private IEnemyState currentState;
    private IAttackStrategy currentAttack;

    private void OnEnable()
    {
        EventManager.RegisterListener(this);
    }

    private void OnDisable()
    {
        EventManager.UnregisterListener(this);
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    // Cambiar estado del enemigo
    public void ChangeState(IEnemyState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState?.EnterState(this);
    }

    // Cambiar ataque
    public void SetAttackStrategy(IAttackStrategy attackStrategy)
    {
        currentAttack = attackStrategy;
    }

    // Ejecutar ataque
    public void PerformAttack(Transform target)
    {
        currentAttack?.ExecuteAttack(this, target);
    }

    // Reacción a eventos externos
    public void OnEnemyEvent(EnemyEvent enemyEvent)
    {
        if (enemyEvent.EventType == "PlayerDetected")
        {
            // Ejemplo: cambiar a estado de alerta
            Debug.Log($"{name} detectó al jugador!");
        }
    }
}
