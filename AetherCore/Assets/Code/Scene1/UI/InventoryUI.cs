using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }

    [Header("Slots (fondos)")]
    public Image slot1;
    public Image slot2;

    [Header("Iconos dentro de los slots")]
    public GameObject slot1Icon;
    public GameObject slot2Icon;

    [Header("Colores")]
    public Color baseColor = new Color(0.8f, 0.8f, 0.8f); // gris claro
    public Color selectedColor = Color.yellow;            // slot seleccionado (slot1 siempre)

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        slot1Icon.SetActive(false);
        slot2Icon.SetActive(false);

        slot1.color = selectedColor;
        slot2.color = baseColor;
    }

    public void RefreshUI(Item[] slots, int selectedSlotAlwaysZero)
    {
        // Iconos visibles solo si hay item
        slot1Icon.SetActive(slots[0] != null);
        slot2Icon.SetActive(slots[1] != null);

        // Colores
        slot1.color = selectedColor; // siempre iluminado
        slot2.color = baseColor;     // slot2 nunca iluminado
    }
}
