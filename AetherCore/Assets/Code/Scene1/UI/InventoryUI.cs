using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    public Image[] slotImages;
    public Color emptyColor = Color.white; // 🔄 ahora blanco
    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.white;
    public Color usedColor = Color.black;

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

    // 🔄 efecto de uso: poner negro y luego volver al color normal
    public void FlashUsedSlot(int slotIndex, float duration = 0.5f)
    {
        StartCoroutine(FlashSlotCoroutine(slotIndex, duration));
    }

    private IEnumerator FlashSlotCoroutine(int slotIndex, float duration)
    {
        if (slotIndex < 0 || slotIndex >= slotImages.Length)
            yield break;

        slotImages[slotIndex].color = usedColor;
        yield return new WaitForSeconds(duration);

        // volver a color normal según si es activo o no
        if (!inventory.slots[slotIndex].IsEmpty)
        {
            slotImages[slotIndex].color = (slotIndex == inventory.activeSlot) ? activeColor : inactiveColor;
        }
        else
        {
            slotImages[slotIndex].color = emptyColor;
        }
    }
}
