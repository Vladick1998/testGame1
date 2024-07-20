using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Контролирует поведение врагов
public class EnemyController : Unit
{
    public bool move;
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerControler.player.transform.position, unitData.MoveSpeed * Time.deltaTime);
            if (transform.position.x - PlayerControler.player.transform.position.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerControler.player.TakeDamage(currentDamage * Time.deltaTime);
        }
    }
}
