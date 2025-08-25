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
            Debug.LogError("El componente asignado no implementa IItemStrategy");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.ReplaceActiveItem(GetItem());
                Destroy(gameObject);
            }
        }
    }

    public Item GetItem()
    {
        return new Item(itemName, icon, itemStrategy, worldPrefab);
    }
}
