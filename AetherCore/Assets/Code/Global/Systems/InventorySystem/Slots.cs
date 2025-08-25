using UnityEngine;

public class Slots
{
    public Item storedItem;
    public bool isEmpty => storedItem == null;
    public void setItem(Item item)
    {
        storedItem = item;
        DebugUtility.Log("Item " + item.itemName + " added to slot.");
    }
    public void clear()
    {
        if (storedItem != null)
        {
            DebugUtility.Log("Item " + storedItem.itemName + " removed from slot.");
            storedItem = null;
        }
    }
}
