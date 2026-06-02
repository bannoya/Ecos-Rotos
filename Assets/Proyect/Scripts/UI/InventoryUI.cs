using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Image[] icons;

    public void RefreshUI()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                icons[i].sprite = inventory.items[i].icon;
                icons[i].enabled = true;
            }
            else
            {
                icons[i].enabled = false;
            }
        }
    }
}