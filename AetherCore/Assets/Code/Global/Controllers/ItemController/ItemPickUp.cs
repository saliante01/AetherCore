using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private Item nearbyItem;

    void Update()
    {
        // Tomar objeto cercano (simulación tecla T)
        if (Input.GetKeyDown(KeyCode.T) && nearbyItem != null)
        {
            Inventory.Instance.AddItem(nearbyItem);
            nearbyItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            nearbyItem = item;
            DebugUtility.Log("Objeto encontrado: " + item.GetName());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null && nearbyItem == item)
        {
            nearbyItem = null;
            DebugUtility.Log("Objeto dejado: " + item.GetName());
        }
    }
}
