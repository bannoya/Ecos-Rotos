using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Image[] slots;

    public void RefreshUI()
    {
        Debug.Log("Items: " + inventory.items.Count);
        Debug.Log("Slots: " + slots.Length);

        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("Slot " + i + ": " + slots[i]);
            if (i < inventory.items.Count)
            {
                Debug.Log("Slot " + i + " Item: " + inventory.items[i].itemName);
                Debug.Log("Icono: " + inventory.items[i].icon);

                slots[i].sprite = inventory.items[i].icon;
                slots[i].enabled = true;
            }
            else
            {
                slots[i].sprite = null;
                slots[i].enabled = false;
            }
        }
    }
}