using UnityEngine;

public class InventoryInputHandler : MonoBehaviour
{
    void Update()
    {
        // Guardar objeto cercano con F
        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemPickUp itemPickUp = FindObjectOfType<ItemPickUp>();
            if (itemPickUp != null)
                itemPickUp.TryPickupItem();
        }

        // Consumir objeto activo con E
        if (Input.GetKeyDown(KeyCode.E))
            Inventory.Instance.UseActiveItem();

        // Intercambiar slots con Q
        if (Input.GetKeyDown(KeyCode.Q))
            Inventory.Instance.SwapSlots();
    }
}
