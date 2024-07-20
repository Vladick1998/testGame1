using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

//Ñêğèïò îòâå÷àşùèé çà ğàáîòó èíâåíòîğÿ.
public class InventoryController : MonoBehaviour
{
    public InventoryÑell[] items = new InventoryÑell[3];//ëó÷øå áû ñäåëàë list íî óæå íàêîäèë òàê
    public InventoryÑell activeCell;
    public GameObject deleteButton;
    public void SetActiveCell(GameObject inventoryÑell)
    {
        if (activeCell.button != null)
            activeCell.button.GetComponent<Button>().image.color = Color.white;
        foreach (InventoryÑell item in items)
        {
            if (inventoryÑell == item.button)
            {
                activeCell = item;
                activeCell.button.GetComponent<Button>().image.color = Color.red;
                deleteButton.SetActive(true);
            }
        }
    }
    public void RemoveActiveItem()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == activeCell)
            {
                Destroy(items[i].item);
                items[i].item = null;
                items[i].icon.enabled = false;
                items[i].icon.sprite = null;
                UpdateText(null, items[i].button.GetComponentInChildren<TextMeshProUGUI>());

            }
        }
    }
    public void AddItem(GameObject itemToAdd)
    {
        bool itemExist = false;
        Item itemToAddData = itemToAdd.GetComponent<Item>();
        if (itemToAddData.itemData.isStackable)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].item)
                {
                    if (items[i].item.GetComponent<Item>().itemData.itemName == itemToAddData.itemData.itemName)
                    {
                        items[i].item.GetComponent<Item>().count += itemToAddData.count;
                        itemExist = true;
                        UpdateText(items[i].item.GetComponent<Item>(), items[i].button.GetComponentInChildren<TextMeshProUGUI>());
                        Destroy(itemToAdd);
                        return;
                    }
                }
            }
        }
        if (!itemExist)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].item == null)
                {
                    items[i].item = itemToAdd;
                    itemToAdd.transform.parent = items[i].button.transform;
                    itemToAdd.transform.localPosition = Vector3.zero;
                    itemExist = true;
                    items[i].icon.sprite = itemToAdd.GetComponent<SpriteRenderer>().sprite;
                    items[i].icon.enabled = true;
                    UpdateText(itemToAddData, items[i].button.GetComponentInChildren<TextMeshProUGUI>());
                    return;
                }
            }
        }
        if (!itemExist)
        {
            Debug.Log("Íå ïîëó÷èëîñü äîáàâèòü ïğåäìåò " + itemToAdd + " òàê êàê èíâåíòàğü ïîëîí");
        }
    }
    public InventoryÑell SearchItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item != null)
            {
                if (items[i].item.GetComponent<Item>().itemData.itemName == itemName)
                    return items[i];
            }
        }
        return null;
    }
    public void SpendItem(InventoryÑell Cell)
    {
        if (Cell.item.GetComponent<Item>().count <= 0)
        {
            Destroy(Cell.item);
            Cell.item = null;
            Cell.icon.enabled = false;
            UpdateText(null, Cell.button.GetComponentInChildren<TextMeshProUGUI>());
        }
        else
            UpdateText(Cell.item.GetComponent<Item>(), Cell.button.GetComponentInChildren<TextMeshProUGUI>());
    }
    private void UpdateText(Item itemToAddData, TextMeshProUGUI text)
    {
        string textData = "Empty"; 
        if (itemToAddData!=null)
        {
            textData = itemToAddData.itemData.itemName;
            if (itemToAddData.count > 1) 
            {
                textData += ": " + itemToAddData.count;
            }
        }    
        text.text = textData;
    }
}
[System.Serializable]
public class InventoryÑell
{
    public GameObject item;
    public GameObject button;
    public Image icon;
}
