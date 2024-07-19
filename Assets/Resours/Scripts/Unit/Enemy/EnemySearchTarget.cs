using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchTarget : MonoBehaviour
{
    [SerializeField]
    EnemyController enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.move = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.move = false;
        }
    }
}
