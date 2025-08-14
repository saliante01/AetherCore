using UnityEngine;

public class EnemyA : Enemy
{
    [Header("Patrulla")]
    public Transform[] patrolPoints;

    private PatrolState patrolState;
    private AlertState alertState;

    public void Initialize(Transform target)
    {
        this.target = target;

        // Crear estados
        patrolState = new PatrolState(patrolPoints);
        alertState = new AlertState();

        // Estado inicial: patrulla
        ChangeState(patrolState);

        // Ataque inicial: melee
        SetAttackStrategy(new MeleeAttack());

        // Configurar detector de alerta
        SetupAlertDetector();
    }

    private void SetupAlertDetector()
    {
        SphereCollider alertZone = gameObject.AddComponent<SphereCollider>();
        alertZone.isTrigger = true;
        alertZone.radius = 5f;

        EnemyAlertDetector detector = gameObject.AddComponent<EnemyAlertDetector>();
        detector.player = target;
        detector.enemy = this;
        detector.stateOnEnter = alertState;
        detector.stateOnExit = patrolState;
    }

    public void EnterAlert()
    {
        // Cambia a ataque a distancia
        SetAttackStrategy(new RangeAttack());
        Debug.Log($"{name} (EnemyA) entra en alerta y listo para ataque a distancia");
    }
}
