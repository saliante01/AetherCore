using UnityEngine;

public class SpeedItem : MonoBehaviour, IItemStrategy
{
    public void Use(GameObject target)
    {
        PlayerStats stats = target.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.Speed();
            Debug.Log("Se aumento la velocidad del player con el item de velocidad.");
        }
    }
}
