using UnityEngine;

public class EnemyAlertDetector : MonoBehaviour
{
    public Transform player;
    public Enemy enemy;
    public IEnemyState stateOnEnter;
    public IEnemyState stateOnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player && stateOnEnter != null)
        {
            enemy.ChangeState(stateOnEnter);

            // Lógica específica de ataque
            if (enemy is EnemyA a) a.EnterAlert();
            else if (enemy is EnemyB b) b.EnterAlert();
            else if (enemy is EnemyC c) c.EnterAlert();

            Debug.Log($"{enemy.name} detectó al jugador y cambió a {stateOnEnter.GetType().Name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player && stateOnExit != null)
        {
            enemy.ChangeState(stateOnExit);
            Debug.Log($"{enemy.name} jugador salió, cambiando a {stateOnExit.GetType().Name}");
        }
    }
}
