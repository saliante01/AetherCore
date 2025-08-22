using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Item[] slots = new Item[2]; // slot1 y slot2

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        RefreshUI();
    }

    // Guardar un objeto en el inventario
    public bool AddItem(Item item)
    {
        // Buscar primer slot vacío
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                item.gameObject.SetActive(false);
                DebugUtility.Log(item.GetName() + " agregado al slot " + (i + 1));
                RefreshUI();
                return true;
            }
        }

        // Si ambos slots ocupados, reemplaza el slot1 (activo)
        DebugUtility.Log(slots[0].GetName() + " reemplazado por " + item.GetName() + " en slot1");
        slots[0] = item;
        item.gameObject.SetActive(false);
        RefreshUI();
        return true;
    }

    // Consumir el item del slot activo (slot1)
    public void UseActiveItem()
    {
        if (slots[0] != null)
        {
            slots[0].Use();
            DebugUtility.Log(slots[0].GetName() + " usado y eliminado del slot1");
            slots[0] = null;
            RefreshUI();
        }
        else
        {
            DebugUtility.Log("Slot1 vacío, no hay objeto para usar");
        }
    }

    // Intercambiar los objetos de los dos slots
    public void SwapSlots()
    {
        Item temp = slots[0];
        slots[0] = slots[1];
        slots[1] = temp;
        DebugUtility.Log("Slots intercambiados");
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (InventoryUI.Instance != null)
            InventoryUI.Instance.RefreshUI(slots, 0); // siempre resalta slot1
    }
}
