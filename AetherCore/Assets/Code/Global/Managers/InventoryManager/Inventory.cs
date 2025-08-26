using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public bool HasAnyItem()
    {
        foreach (var slot in slots)
        {
            if (!slot.IsEmpty)
                return true;
        }
        return false;
    }
    public Slot[] slots = new Slot[2];
    public int activeSlot = 0;

    public event Action<Slot[], int> OnInventoryChanged;

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null) slots[i] = new Slot();
        }
    }
    public Slot GetActiveSlot()
    {
     return slots[activeSlot];
    }

    public void UseActiveItem(GameObject target)
    {
        Slot slot = slots[activeSlot];
        Debug.Log(slot.IsEmpty);
        Debug.Log(slot.storedItem == null);
        if (slot == null || slot.IsEmpty || slot.storedItem == null)
        {
            Debug.Log("No hay item equipado en el slot activo.");
            return;
        }
        slot.storedItem.Use(target);
        TriggerInventoryChanged();
    }




    public void ReplaceActiveItem(Item newItem)
    {
        if (!slots[activeSlot].IsEmpty)
        {
            Debug.Log($"Se botó el item: {slots[activeSlot].storedItem.itemName}");
        }

        slots[activeSlot].SetItem(newItem);
        TriggerInventoryChanged();
    }

    public void SwapActiveSlot()
    {
        activeSlot = (activeSlot + 1) % slots.Length;
        TriggerInventoryChanged();
    }

    private void TriggerInventoryChanged()
    {
        OnInventoryChanged?.Invoke(slots, activeSlot);
    }
}
