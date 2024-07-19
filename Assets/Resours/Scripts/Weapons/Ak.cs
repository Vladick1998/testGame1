using System.Collections;
using System.Collections.Generic;
using Terresquall;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Ak : WeaponController
{
    // Start is called before the first frame update
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
            //Debug.Log(transform.rotation.z);

            GameObject bullet = Instantiate(weaponData.Prefab, firePosition.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + currentSpread));
            bullet.GetComponent<AkProjectile>().weaponData = weaponData;
            //bullet.GetComponent<AkProjectile>().DirectionCheker(new Vector3(VirtualJoystick.GetAxis("Horizontal", 1), VirtualJoystick.GetAxis("Vertical", 1),0).normalized);
            bullet.SetActive(true);
        }
    }
    //IEnumerator attackCoroutine()
    //{
    //    yield return;
    //}
}
