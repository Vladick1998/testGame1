using System;
using System.Collections;
using System.Collections.Generic;
using Terresquall;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//Скрипт отвечает за передвижение и статы игрока
public class PlayerControler : Unit
{
    [HideInInspector]
    public static PlayerControler player;
    [HideInInspector]
    public Vector2 playerInput;
    [SerializeField]
    private Rigidbody2D playerRigidbody2D;
    public PlayerScriptableObjet playerData;
    public float currentXp;
    public float currentXpToLvlUp;
    public float currentXpToLvlUpMultiplier;
    public int currentLvl;
    void Start()
    {
        currentXpToLvlUp = playerData.XpToLevelUp;
        currentXpToLvlUpMultiplier = playerData.XpToLevelUpMultiplier;
        Instantiate(playerData.StartingWeapon, gameObject.transform);
        player = this;
    }
    void Update()
    {
        InputManagment();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void InputManagment()
    {
        playerInput = new Vector2(VirtualJoystick.GetAxis("Horizontal", 0), VirtualJoystick.GetAxis("Vertical", 0)).normalized;
    }
    void Move()
    {
        //playerRigidbody2D.MovePosition(playerRigidbody2D.position + playerInput * Time.deltaTime * MoveSpeed);
        playerRigidbody2D.velocity = playerInput * unitData.MoveSpeed;
    }
    public void IncreaseXp(float takeXp)
    {
        currentXp += takeXp;
        if (currentXp > currentXpToLvlUp)
        {
            currentLvl += 1;
            currentXpToLvlUp *= currentXpToLvlUpMultiplier;
        }
    }
    public override void Kill()
    {
        Time.timeScale = 0;
        GameManager.gameManager.Restart();
    }
}

