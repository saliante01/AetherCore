using UnityEngine;

public class HealItem : Item
{
    void Awake()
    {
        itemName = "HealItem";
    }

    public override void Use()
    {
        DebugUtility.Log(itemName + " usado: Salud +10 (simulado)");
    }
}
