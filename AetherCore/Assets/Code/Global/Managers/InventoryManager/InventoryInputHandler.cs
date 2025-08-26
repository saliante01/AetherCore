using UnityEngine;

public class InventoryInputHandler : MonoBehaviour
{
    public Inventory inventory; // referencia pública
    public GameObject player;

    private void Start()
    {
        if (inventory == null)
        {
            Debug.LogError("No se asignó Inventory en el inspector.");
        }

        if (player == null)
        {
            player = this.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            inventory.UseActiveItem(player);

        if (Input.GetKeyDown(KeyCode.Q))
            inventory.SwapActiveSlot();

        if (Input.GetKeyDown(KeyCode.K))
            DropActiveItem();
    }


    private void DropActiveItem()
    {
        Slot slot = inventory.GetActiveSlot();
        if (!slot.IsEmpty && slot.storedItem.worldPrefab != null)
        {
            Vector3 dropPos = player.transform.position + player.transform.forward * 2f;
            Instantiate(slot.storedItem.worldPrefab, dropPos, Quaternion.identity);
            slot.Clear();
        }
    }
}
