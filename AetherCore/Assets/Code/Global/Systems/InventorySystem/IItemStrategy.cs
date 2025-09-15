using UnityEngine;

public interface IItemStrategy
{
    bool Use(GameObject target);
     float GetCooldownRemaining();
}

