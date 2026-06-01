using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new();
    [SerializeField] private InventoryUI inventoryUI;
    public void AddItem(Item item)
    {
        items.Add(item);

        Debug.Log("Objeto agregado: " + item.itemName);

        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI NO asignado");
            return;
        }

        inventoryUI.RefreshUI();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
    
