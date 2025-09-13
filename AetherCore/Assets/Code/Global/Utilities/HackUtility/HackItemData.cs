using UnityEngine;

[CreateAssetMenu(fileName = "NewHackItem", menuName = "HackMenu/Item")]
public class HackItemData : ScriptableObject
{
    public string itemName;       // Nombre del item
    public Sprite icon;           // Icono para mostrar en el botón
    public GameObject worldPrefab; // Prefab opcional si después quieres soltarlo
    public ItemType type;         // Tipo de item (Heal, Speed, etc.)
}

public enum ItemType
{
    Heal,
    Speed
    // Puedes agregar más tipos (Shield, DamageBoost, etc.)
}
