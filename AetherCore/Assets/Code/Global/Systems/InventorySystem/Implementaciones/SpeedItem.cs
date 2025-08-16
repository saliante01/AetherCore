using UnityEngine;

public class SpeedItem : Item
{
    void Awake()
    {
        itemName = "SpeedItem";
    }

    public override void Use()
    {
        DebugUtility.Log(itemName + " usado: Velocidad aumentada (simulado)");
    }
}
