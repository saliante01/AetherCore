using UnityEngine;

public class EnemyC : Enemy
{
    [Header("Patrulla")]
    public Transform[] patrolPoints;

    private void Start()
    {
        // Estado inicial: patrulla
        PatrolState patrolState = new PatrolState(patrolPoints);
        ChangeState(patrolState);

        // Estrategia de ataque inicial: melee
        SetAttackStrategy(new MeleeAttack());
    }


    public void EnterAlert()
    {
        // No hacemos nada, simplemente debug
        Debug.Log($"{name} (EnemyC) sigue en alerta sin atacar");
    }
}
