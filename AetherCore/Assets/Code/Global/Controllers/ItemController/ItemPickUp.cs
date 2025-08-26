using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public MonoBehaviour itemStrategyComponent;
    private IItemStrategy itemStrategy;
    public GameObject worldPrefab;
    public string itemName;
    public Sprite icon;

    private void Awake()
    {
        itemStrategy = itemStrategyComponent as IItemStrategy;
        if (itemStrategy == null)
            Debug.LogWarning($"El componente asignado no implementa IItemStrategy para el item '{itemName}'");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                Item newItem = GetItem();
                inventory.ReplaceActiveItem(newItem); 
                Destroy(gameObject);
            }
        }
    }

    public Item GetItem()
    {
        return new Item(itemName, icon, itemStrategy, worldPrefab);
    }
}
