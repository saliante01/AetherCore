using UnityEngine;

public class HealItem : MonoBehaviour, IItemStrategy
{
    public void Use(GameObject target)
    {
        PlayerStats stats = target.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.Heal(); // ahora coincide con tu PlayerStats actual
            Debug.Log("Se curo al player con el item de curación.");
        }
    }
}
