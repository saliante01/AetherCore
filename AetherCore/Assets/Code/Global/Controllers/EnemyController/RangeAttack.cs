using UnityEngine;

public class RangeAttack : IAttackStrategy
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    public void ExecuteAttack(Enemy enemy, Transform target)
    {
        Debug.Log($"{enemy.name} dispara un proyectil a {target.name}");

        if (projectilePrefab != null && target != null)
        {
            GameObject projectile = Object.Instantiate(
                projectilePrefab,
                enemy.transform.position + Vector3.up, // Un poco elevado
                Quaternion.identity
            );

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (target.position - enemy.transform.position).normalized;
                rb.linearVelocity = Vector3.zero; // Reinicia la velocidad antes de aplicar la fuerza
                rb.angularVelocity = Vector3.zero; // Opcional: reinicia la velocidad angular
                rb.AddForce(direction * projectileSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
