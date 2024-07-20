using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт контролирует все анимации игрока
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerControler playerControler;
    [SerializeField]
    private Transform Legs;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerControler = GetComponent<PlayerControler>();
    }
    void Update()
    {
        if (playerControler.playerInput.x != 0 || playerControler.playerInput.y != 0)
        {
            DirectionCheker();
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
    void DirectionCheker()
    {
        if (playerControler.playerInput.x < 0)
        {
            Legs.localScale = new Vector3(-1,1,1);
        }
        else
        {
            Legs.localScale = Vector3.one;
        }
    }
}
