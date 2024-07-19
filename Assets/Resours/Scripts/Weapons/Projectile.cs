using System.Collections;
using System.Collections.Generic;
using Terresquall;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float speed;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentPierce;
    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    public void DirectionCheker(Vector3 dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //transform.position += direction * currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.right*currentSpeed*Time.deltaTime);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponent<Unit>();
        if (unit)
            unit.TakeDamage(currentDamage);
    }
    private void ReducePierce()
    {
        currentPierce -= 1;
        if (currentPierce<=0)
        {
            Destroy(gameObject);
        }
    }
}
