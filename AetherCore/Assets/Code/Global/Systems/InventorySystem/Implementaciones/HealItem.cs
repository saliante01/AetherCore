using UnityEngine;

public class HealItem : MonoBehaviour, IItemStrategy
{
    public float cooldown = 5f;
    private float lastUseTime = -Mathf.Infinity;

    public bool Use(GameObject target)
    {
        if (Time.time < lastUseTime + cooldown)
        {
            Debug.Log($"HealItem en cooldown. Espera {Mathf.Ceil((lastUseTime + cooldown) - Time.time)}s");
            return false;
        }

        PlayerStats stats = target.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.Heal();
            Debug.Log("Se curó al player con el item de curación.");
        }

        lastUseTime = Time.time;
        return true;
    }

    public float GetCooldownRemaining()
    {
        return Mathf.Max(0f, (lastUseTime + cooldown) - Time.time);
    }

    
    
}
