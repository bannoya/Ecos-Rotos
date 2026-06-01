using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void PickUp(Inventory inventory)
    {
        inventory.AddItem(item);

        Destroy(gameObject);
    }
}