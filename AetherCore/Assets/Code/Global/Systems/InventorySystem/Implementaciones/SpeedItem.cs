using UnityEngine;

public class SpeedItem : MonoBehaviour, IItemStrategy
{
    public float cooldown = 5f;
    private float lastUseTime = -Mathf.Infinity;

    public bool Use(GameObject target)
    {
        if (Time.time < lastUseTime + cooldown)
        {
            Debug.Log($"SpeedItem en cooldown. Espera {Mathf.Ceil((lastUseTime + cooldown) - Time.time)}s");
            return false;
        }

        PlayerStats stats = target.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.Heal();
            Debug.Log("Se aplicó velocidad al player con el item de velocidad.");
        }

        lastUseTime = Time.time;
        return true;
    }
    public float GetCooldownRemaining()
    {
        return Mathf.Max(0f, (lastUseTime + cooldown) - Time.time);
    }
}

