using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private Item nearbyItem;

    // Llamar desde InventoryInputHandler con F
    public void TryPickupItem()
    {
        if (nearbyItem != null)
        {
            Inventory.Instance.AddItem(nearbyItem);
            DebugUtility.Log("Objeto " + nearbyItem.GetName() + " recogido con F");
            nearbyItem = null;
        }
        else
        {
            DebugUtility.Log("No hay objetos cercanos para recoger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            nearbyItem = item;
            DebugUtility.Log("Objeto cercano: " + item.GetName());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null && nearbyItem == item)
        {
            nearbyItem = null;
            DebugUtility.Log("Objeto salido de rango: " + item.GetName());
        }
    }
}
