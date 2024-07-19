using System;
using System.Collections;
using System.Collections.Generic;
using Terresquall;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    public Transform firePosition;
    private float currentCooldown;
    [SerializeField]
    private List<GameObject> targets;
    private GameObject currentTarget;
    public int currentMagazineÑapacity;
    public int CurrentMagazineCapacity
    {
        get 
        {

            return currentMagazineÑapacity;
        }
        set 
        {
            currentMagazineÑapacity = value;
            currentMagazineCapacityText.text = "Attack\n"+currentMagazineÑapacity;
        }
    }
    public TextMeshProUGUI currentMagazineCapacityText;
    public List<ItemScriptableObject> suitableAmmo;
    public InventoryÑell ammoData;

    protected virtual void Start()
    {
        currentMagazineCapacityText = AttackState.buttonText;
        targets = new List<GameObject>();
        currentCooldown = weaponData.CooldownDuration;
        CurrentMagazineCapacity = weaponData.MagazineÑapacity;
    }
    protected virtual void Update()
    {
        if (targets.Count > 0)
        {
            SearchTarget();
            Rotate();
        }
        currentCooldown -= Time.deltaTime;
        if (AttackState.attackState && currentCooldown <= 0)
        {
            Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        targets.Remove(collision.gameObject);
    }
    void SearchTarget()
    {
        float minDist = 100;
        foreach (GameObject target in targets)
        {
            float currentDist = Vector3.Distance(transform.position, target.transform.position);
            if (currentDist < minDist)
            {
                currentTarget = target;
                minDist = currentDist;
            }
        }
    }
    void Rotate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = currentTarget.transform.position.x - currentPosition.x;
        currentPosition.y = currentTarget.transform.position.y - currentPosition.y;

        float angle = Mathf.Atan2(currentPosition.y, currentPosition.x) * Mathf.Rad2Deg;
        //Debug.Log(angle + "\n" + currentPosition.x);
        if (angle != 0)
        {
            if (currentPosition.x > 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            else
                transform.rotation = Quaternion.Euler(new Vector3(180, 0, (angle)) * -1);
        }

    }
    protected virtual void reloadAmmo()
    {
        if (ammoData == null)
            for (int i = 0; i < suitableAmmo.Count; i++)
                ammoData = PlayerControler.player.GetComponent<InventoryController>().SearchItem(suitableAmmo[i].itemName);
        else if (ammoData.item != null)
        {
            int inventoryAmmo = ammoData.item.GetComponent<Item>().count;
            if (inventoryAmmo > weaponData.MagazineÑapacity)
            {
                inventoryAmmo -= weaponData.MagazineÑapacity;

                CurrentMagazineCapacity = weaponData.MagazineÑapacity;
                ammoData.item.GetComponent<Item>().count -= weaponData.MagazineÑapacity;
            }
            else
            {
                CurrentMagazineCapacity = inventoryAmmo;
                ammoData.item.GetComponent<Item>().count = 0;
            }
            PlayerControler.player.GetComponent<InventoryController>().SpendItem(ammoData);
            currentCooldown = weaponData.ReloadCooldown;
            currentMagazineCapacityText.text = "Reload";
            StartCoroutine(Reloaded());
        }
        else
        {
            ammoData = null;
        }
    }
    IEnumerator Reloaded()
    {
        yield return new WaitForSeconds(weaponData.ReloadCooldown);
        currentMagazineCapacityText.text = "Attack\n" + currentMagazineÑapacity;
    }
    protected virtual void Attack()
    {

        if (CurrentMagazineCapacity <= 0)
        {
            reloadAmmo();
            return;
        }
        else
            currentCooldown = weaponData.CooldownDuration;
        CurrentMagazineCapacity -= 1;

    }
}
