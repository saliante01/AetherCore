using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public MonoBehaviour itemStrategyComponent; // arrastras HealItem u otra estrategia
    private IItemStrategy itemStrategy;

    public string itemName;
    public Sprite icon;

    void Awake()
    {
        itemStrategy = itemStrategyComponent as IItemStrategy;
        if (itemStrategy == null)
        {
            Debug.LogError("El componente asignado no implementa IItemStrategy");
        }
    }

    public Item GetItem()
    {
        return new Item(itemName, icon, itemStrategy);
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.ReplaceActiveItem(GetItem());
            Destroy(gameObject);
        }
    }
}