using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Slots[] slots = new Slots[2];
    private int activeSlot = 0;

    // Evento que avisa a la UI
    public event Action<Slots[], int> OnInventoryChanged;

    public void UseActiveItem(GameObject target)
    {
        if (!slots[activeSlot].isEmpty)
        {
            slots[activeSlot].storedItem.Use(target);
            slots[activeSlot].clear();
            TriggerInventoryChanged();
        }
    }

    public void ReplaceActiveItem(Item newItem)
    {
        if (!slots[activeSlot].isEmpty)
        {
            Debug.Log($"Se botó el item: {slots[activeSlot].storedItem.itemName}");
        }

        slots[activeSlot].setItem(newItem);
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