using UnityEngine;

public class HackMenuController : MonoBehaviour
{
    public Inventory playerInventory;

    public void AddHackItem(HackItemData data)
    {
        if (playerInventory == null || data == null)
        {
            Debug.LogWarning("HackMenuController: falta referencia al inventario o al item.");
            return;
        }

        // Crear estrategia según el tipo
        IItemStrategy strategy = null;
        switch (data.type)
        {
            case ItemType.Heal:
                strategy = new HealItem(); // usa la estrategia existente
                break;
            case ItemType.Speed:
                strategy = new SpeedItem();
                break;
        }

        // Crear el item real
        Item newItem = new Item(data.itemName, data.icon, strategy, data.worldPrefab);

        // Añadir al inventario
        playerInventory.ReplaceActiveItem(newItem);

        Debug.Log($"[HackMenu] Item agregado: {data.itemName}");
    }
}
