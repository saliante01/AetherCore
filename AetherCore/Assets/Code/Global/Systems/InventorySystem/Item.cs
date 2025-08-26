using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    private IItemStrategy itemStrategy;
    public GameObject worldPrefab;
    public Item(string name, Sprite icon, IItemStrategy strategy,GameObject prefab)
    {
        itemName = name;
        this.icon = icon;
        itemStrategy = strategy;
        worldPrefab = prefab;
    }

    public void Use(GameObject target)
    {
    if (itemStrategy == null)
    {
        Debug.LogWarning($"El item '{itemName}' no tiene estrategia de uso.");
        return;
    }

    itemStrategy.Use(target);
    Debug.Log($"Item Usado: {itemName}");
    }


}
