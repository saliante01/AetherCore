using UnityEngine;

public class InventoryInputHandler : MonoBehaviour
{
    private Inventory inventory;
    private GameObject target;

    private void Awake()
    {
        inventory=GetComponent<Inventory>();
        target=gameObject;
    }
    void Update()
    {
        // Guardar objeto cercano con F
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            ItemPickUp itemPickUp = FindObjectOfType<ItemPickUp>();
            if (itemPickUp != null)
                itemPickUp.TryPickupItem();
        }*/

        // Consumir objeto activo con E
        if (Input.GetKeyDown(KeyCode.E))
            inventory.UseActiveItem(target);

        // Intercambiar slots con Q
        if (Input.GetKeyDown(KeyCode.Q))
            inventory.SwapActiveSlot();
    }
}
