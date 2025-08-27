using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public MonoBehaviour itemStrategyComponent;
    private IItemStrategy itemStrategy;
    public GameObject worldPrefab;
    public string itemName;
    public Sprite icon;

    private Inventory playerInventory; 
    private bool playerInside = false;

    private void Awake()
    {
        itemStrategy = itemStrategyComponent as IItemStrategy;
        if (itemStrategy == null)
            Debug.LogWarning($"El componente asignado no implementa IItemStrategy para el item '{itemName}'");
    }

    private void Update()
    {
        
        if (playerInside && Input.GetKeyDown(KeyCode.F) && playerInventory != null)
        {   
            Debug.Log($"Recogiendo item: {itemName}");
            TakeItem();
        }
    }

    private void TakeItem()
    {
        Item newItem = new Item(itemName, icon, itemStrategy, worldPrefab);
        playerInventory.ReplaceActiveItem(newItem);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Solo reaccionar si el objeto tiene tag "Player"
        if (other.CompareTag("Player"))
        {
            playerInventory = other.GetComponent<Inventory>();
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            playerInventory = null;
        }
    }
}
