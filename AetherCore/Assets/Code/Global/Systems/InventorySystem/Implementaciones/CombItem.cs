using UnityEngine;

public class CombItem : Item
{
    void Awake()
    {
        itemName = "CombItem";
    }

    public override void Use()
    {
        DebugUtility.Log(itemName + " usado: Ataque aumentado (simulado)");
    }
}
