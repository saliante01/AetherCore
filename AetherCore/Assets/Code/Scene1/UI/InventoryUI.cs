using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Referencias de UI")]
    public Image[] slotImages;
    public Sprite defaultSlotSprite;

    [Header("Colores")]
    public Color slot1Color = Color.white;   // Slot 1 siempre blanco
    public Color slot2Color = Color.red;     // Slot 2 siempre rojo
    public Color usedColor = Color.black;    // Color cuando el item está en cooldown
    public Color emptyColor = Color.gray;    // Slot vacío

    private Inventory inventory;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        if (inventory != null)
        {
            inventory.OnInventoryChanged += UpdateUI;
            UpdateUI(inventory.slots, inventory.activeSlot);
        }
        else
        {
            Debug.LogError("No se encontró el Inventory en la escena.");
        }
    }

    private void Update()
{
    if (inventory == null) return;

    for (int i = 0; i < inventory.slots.Length; i++)
    {
        Slot slot = inventory.slots[i];

        if (!slot.IsEmpty && slot.storedItem != null)
        {
            bool onCooldown = slot.storedItem.GetCooldownRemaining() > 0f;

            // Slot 1 blanco, Slot 2 rojo, negro si en cooldown
            slotImages[i].color = onCooldown ? usedColor : (i == 0 ? slot1Color : slot2Color);
        }
        else
        {
            slotImages[i].color = emptyColor;
        }
    }
}

    public void UpdateUI(Slot[] slots, int activeSlot)
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < slots.Length && !slots[i].IsEmpty && slots[i].storedItem != null)
            {
                slotImages[i].sprite = slots[i].storedItem.icon;
                slotImages[i].color = i == 0 ? slot1Color : slot2Color;
            }
            else
            {
                slotImages[i].sprite = defaultSlotSprite;
                slotImages[i].color = emptyColor;
            }
        }
    }
}
