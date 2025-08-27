using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    public Image[] slotImages;
    //public Color emptyColor = Color.white;
    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.red;
    public Color usedColor = Color.gray;
    public Sprite defaultSlotSprite; 

    private Inventory inventory;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        if (inventory != null)
        {
            inventory.OnInventoryChanged += UpdateUI;
         // no hace falta llamar a TriggerInventoryChanged
        }
    }




    private void UpdateUI(Slot[] slots, int activeSlot)
{
    for (int i = 0; i < slotImages.Length; i++)
    {
        if (i < slots.Length && !slots[i].IsEmpty)
        {
            slotImages[i].sprite = slots[i].storedItem.icon;
            // 🔹 solo pintar activo/inactivo si hay item
            slotImages[i].color = i == activeSlot ? activeColor : inactiveColor;
        }
        else
        {
            slotImages[i].sprite = defaultSlotSprite; 
            slotImages[i].color = Color.white; // slot vacío no se pinta
        }
    }
}




  
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
          //  slotImages[slotIndex].color = emptyColor;
        }
    }
}
