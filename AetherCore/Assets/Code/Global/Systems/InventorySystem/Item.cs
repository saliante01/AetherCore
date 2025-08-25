using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    private IItemStrategy itemStrategy;

    public Item(string name, Sprite icon, IItemStrategy strategy)
    {
        itemName = name;
        this.icon = icon;
        itemStrategy = strategy;
    }
    public void Use(GameObject target)
    {
        itemStrategy?.Use(target);
        DebugUtility.Log($"Used item: {itemName}");
    }
}
