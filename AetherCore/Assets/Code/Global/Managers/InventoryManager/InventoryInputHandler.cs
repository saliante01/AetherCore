using UnityEngine;

public class InventoryInputHandler : MonoBehaviour
{
    void Update()
    {
        // Usar slot 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Inventory.Instance.UseItem(0);

        // Usar slot 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Inventory.Instance.UseItem(1);

        // Intercambiar slots (tecla M)
        if (Input.GetKeyDown(KeyCode.M))
            Inventory.Instance.SwapItems(0, 1);
    }
}
