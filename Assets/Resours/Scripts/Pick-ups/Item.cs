using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Основной скрипт для предметов которые можно подобрать в инвентарь.
public class Item : MonoBehaviour, iCollectable
{
    public int count;
    public ItemScriptableObject itemData;

    public virtual void Collect()
    {
        PlayerControler.player.GetComponent<InventoryController>().AddItem(gameObject);
    }
}
