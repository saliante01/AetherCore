using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image[] slotImages;
    public Color emptyColor = Color.black;
    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.white;

    private Inventory inventory;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        if (inventory != null)
        {
            inventory.OnInventoryChanged += UpdateUI;
            UpdateUI(inventory.slots, 0);
        }
    }

    private void UpdateUI(Slot[] slots, int activeSlot)
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < slots.Length && !slots[i].IsEmpty)
            {
                slotImages[i].sprite = slots[i].storedItem.icon;
                slotImages[i].color = i == activeSlot ? activeColor : inactiveColor;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].color = emptyColor;
            }
        }
    }
}
