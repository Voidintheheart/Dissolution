using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Items currentItem;
    public Image customCursor;

    public Slots[] craftingSlots;

    public List<Items> itemList;
    public string[] recipes;
    public Items[] recipeResults;
    public Slots resultSlot;

    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            if(currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slots nearestSlot= null;
                float shortestDistance = float.MaxValue;

                foreach (Slots slot in craftingSlots) {
                    float dist = Vector2.Distance (Input.mousePosition, slot.transform.position);
                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;

                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                itemList[nearestSlot.index] = currentItem; 
                currentItem = null;
            }
        }
        CheckForCreatedRecipe();
    }
    void CheckForCreatedRecipe()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach (Items item in itemList)
        {
            if(item != null)
            {
                currentRecipeString += item.itemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }
        for(int i = 0; i <recipes.Length; i++)
        {
            if (recipes[i] == currentRecipeString) { 
                resultSlot.gameObject.SetActive (true);
                resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                resultSlot.item = recipeResults[i];
            }
        }
    }
    public void OnclickSlots(Slots slot)
    {
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipe();
    }
    public void OuMouseDownItem(Items item)
    {
        if(currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;

        }
    }
}
