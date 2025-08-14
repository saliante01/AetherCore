using UnityEngine;

public class PatrolState : IEnemyState
{
    private int currentWaypointIndex = 0;
    private Transform[] waypoints;

    public PatrolState(Transform[] patrolPoints)
    {
        waypoints = patrolPoints;
    }

    public void EnterState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} entra en estado de patrulla");
    }

    public void UpdateState(Enemy enemy)
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform targetPoint = waypoints[currentWaypointIndex];
        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            targetPoint.position,
            enemy.speed * Time.deltaTime
        );

        if (Vector3.Distance(enemy.transform.position, targetPoint.position) < 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log($"{enemy.name} sale del estado de patrulla");
    }
}
