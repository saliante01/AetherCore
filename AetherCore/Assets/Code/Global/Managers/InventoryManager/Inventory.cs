using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
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
        if (!slots[activeSlot].IsEmpty)
        {
            slots[activeSlot].storedItem.Use(target);
            slots[activeSlot].Clear();
            TriggerInventoryChanged();
        }
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
