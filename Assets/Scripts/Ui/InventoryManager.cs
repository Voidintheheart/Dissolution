using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;

    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;
    public Shooter shooter; 

    void Start()
    {
        menuActivated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            menuActivated = !menuActivated;
            InventoryMenu.SetActive(menuActivated);
            Time.timeScale = menuActivated ? 0 : 1;
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);
                if (leftOverItems > 0)
                    return AddItem(itemName, leftOverItems, itemSprite);

                return 0;
            }
        }

        return quantity; 
    }

    public void DeselectAllSlots()
    {
        foreach (var slot in itemSlot)
        {
            slot.selectedShader.SetActive(false);
            slot.thisItemSelected = false;
        }
    }

    public bool UseItem(string itemName)
    {
        foreach (var item in itemSOs)
        {
            if (item.itemName == itemName)
            {
                if (item.projectilePrefab != null && shooter != null)
                {
                    shooter.SetProjectile(item.projectilePrefab, item.projectileSprite); // Cambia proyectil
                }

                return item.UseItem(); // Ejecuta lógica del item
            }
        }

        return false; // Si no se encontró ningún item
    }

}
