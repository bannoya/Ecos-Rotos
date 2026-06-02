using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private bool pickedUp = false;

    public void PickUp(Inventory inventory)
    {
        if (pickedUp) return;

        pickedUp = true;

        gameObject.SetActive(false);

        inventory.AddItem(item);
    }
}