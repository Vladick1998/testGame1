using System.Collections;
using System.Collections.Generic;
using Terresquall;
using UnityEngine;
using UnityEngine.Windows.Speech;

//Ñêðèïò ñèìóëèðóåò ñòðåëüáó èç ak
public class Ak : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();
        if (currentMagazineÑapacity > 0)
        {
            float currentSpread = Random.Range(weaponData.Spread * -1, weaponData.Spread);
            GameObject bullet = Instantiate(weaponData.Prefab, firePosition.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + currentSpread));
            bullet.GetComponent<AkProjectile>().weaponData = weaponData;
            bullet.SetActive(true);
        }
    }
}
