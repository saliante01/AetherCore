using UnityEngine;

[System.Serializable]
public class Slot
{
    public Item storedItem;
    public bool IsEmpty => storedItem == null;

    public void SetItem(Item item)
    {
        storedItem = item;
        Debug.Log("Item " + item.itemName + " added to slot.");
    }

    public void Clear()
    {
        if (storedItem != null)
        {
            Debug.Log("Item " + storedItem.itemName + " removed from slot.");
            storedItem = null;
        }
    }
}
