using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Item[] slots = new Item[2]; // slots 1 y 2

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DebugUtility.Log("Inventory iniciado con " + slots.Length + " slots");
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                item.gameObject.SetActive(false); // objeto desaparece del mundo
                DebugUtility.Log(item.GetName() + " agregado al slot " + (i + 1));
                return true;
            }
        }
        DebugUtility.Log("No hay slots libres para " + item.GetName());
        return false;
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < slots.Length && slots[slotIndex] != null)
        {
            slots[slotIndex].Use();               // uso del item
            DebugUtility.Log(slots[slotIndex].GetName() + " eliminado del slot " + (slotIndex + 1));
            slots[slotIndex] = null;              // eliminar del slot
        }
        else
        {
            DebugUtility.Log("Slot " + (slotIndex + 1) + " vacío");
        }
    }

    public void SwapItems(int slotA, int slotB)
    {
        if (slotA < 0 || slotA >= slots.Length || slotB < 0 || slotB >= slots.Length) return;

        Item temp = slots[slotA];
        slots[slotA] = slots[slotB];
        slots[slotB] = temp;

        DebugUtility.Log("Items intercambiados: slot " + (slotA + 1) + " ↔ slot " + (slotB + 1));
    }
}
