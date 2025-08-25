using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private Color activeColor = Color.yellow;
    [SerializeField] private Color inactiveColor = Color.white;

    void Start()
    {
        var inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            Bind(inventory);
        }
    }

    public void Bind(Inventory inventory)
    {
        inventory.OnInventoryChanged += UpdateUI;
        UpdateUI(inventory.slots, 0);
    }

    private void OnDestroy()
    {
        var inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            inventory.OnInventoryChanged -= UpdateUI;
        }
    }

    private void UpdateUI(Slots[] slots, int activeSlot)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isEmpty && slots[i].storedItem.icon != null)
            {
                slotIcons[i].sprite = slots[i].storedItem.icon;
                slotIcons[i].enabled = true;
            }
            else
            {
                slotIcons[i].enabled = false;
            }

            slotIcons[i].color = (i == activeSlot) ? activeColor : inactiveColor;
        }
    }
}