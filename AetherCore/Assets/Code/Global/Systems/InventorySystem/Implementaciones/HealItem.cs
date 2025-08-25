using UnityEngine;

public class HealItem : MonoBehaviour, IItemStrategy
{
    public int healAmount = 10; // editable en Inspector

    // Este método implementa la estrategia
    public void Use(GameObject target)
    {
        PlayerStats stats = target.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.Heal();
            Debug.Log("Curando " + healAmount);
        }
    }
}