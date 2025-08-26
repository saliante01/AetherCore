using UnityEngine;

[System.Serializable]
public class Slot
{
    public Item storedItem;
    public bool IsEmpty => storedItem == null;

    public void SetItem(Item item)
    {
        storedItem = item;
        Debug.Log("Item " + item.itemName + " añadido al slot.");
    }

    public void Clear()
    {
        if (storedItem != null)
        {
            Debug.Log("Item " + storedItem.itemName + " removido del slot.");
            storedItem = null;
        }
    }
}
