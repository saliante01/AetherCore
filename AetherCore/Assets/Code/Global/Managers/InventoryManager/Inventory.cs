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
            if (slots[i] == null)
                slots[i] = new Slot();

            slots[i].storedItem = null;
        }

        // Disparar evento al inicio para que la UI se actualice
        OnInventoryChanged?.Invoke(slots, activeSlot);
    }

    public Slot GetActiveSlot()
    {
        return slots[activeSlot];
    }

    public void UseActiveItem(GameObject target)
    {
        if (activeSlot != 0)
        {
            Debug.Log("Solo el slot 1 puede usar items. Haz swap primero.");
            return;
        }

        Slot slot = slots[0];
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
        // buscar primer slot vacío
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty)
            {
                slots[i].SetItem(newItem);
                TriggerInventoryChanged();
                return;
            }
        }

        // si no hay espacio, reemplazar el activo
        Debug.Log($"Se reemplazó el item: {slots[activeSlot].storedItem.itemName}");
        slots[activeSlot].SetItem(newItem);
        TriggerInventoryChanged();
    }

    public void SwapActiveSlot()
    {
        // intercambiar items entre slot[0] y slot[1]
        Item temp = slots[0].storedItem;
        slots[0].storedItem = slots[1].storedItem;
        slots[1].storedItem = temp;

        TriggerInventoryChanged();
        Debug.Log("Slots intercambiados.");
    }

    private void TriggerInventoryChanged()
    {
        OnInventoryChanged?.Invoke(slots, activeSlot);
    }
}
