using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт собирает предметы с пола.ы
public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out iCollectable collectable))
        {
            collectable.Collect();
        }
    }
}
