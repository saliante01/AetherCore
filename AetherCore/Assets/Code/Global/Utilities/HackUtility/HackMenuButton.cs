using UnityEngine;
using UnityEngine.UI;

public class HackMenuButton : MonoBehaviour
{
    public HackItemData itemData; // El item que representa este botón
    private HackMenuController controller;

    private void Start()
    {
        controller = Object.FindFirstObjectByType<HackMenuController>();

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (controller != null && itemData != null)
        {
            controller.AddHackItem(itemData);
        }
        else
        {
            Debug.LogWarning("HackMenuButton: falta controller o itemData.");
        }
    }
}
