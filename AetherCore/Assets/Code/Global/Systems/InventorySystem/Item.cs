using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName = "Item";

    public virtual void Use()
    {
        DebugUtility.Log(itemName + " usado");
    }

    public string GetName()
    {
        return itemName;
    }
}
