using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//Скрипт проверяет зажата ли кнопка атаки и хранит эту информацию в себе
public class AttackState : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool attackState;
    public static TextMeshProUGUI buttonText;
    private void Start()
    {
        attackState = false;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        attackState = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        attackState= false;
    }
}
