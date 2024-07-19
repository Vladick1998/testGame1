using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObjects", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    [SerializeField]
    private float damage;
    public float Damage { get => damage; private set => damage = value; }
    [SerializeField]
    private float speed;
    public float Speed { get => speed; private set => speed = value; }
    [SerializeField]
    private float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }
    [SerializeField]
    private int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
    [SerializeField]
    private int magazineÑapacity;
    public int MagazineÑapacity { get => magazineÑapacity; private set => magazineÑapacity = value; }
    [SerializeField]
    private float reloadCooldown;
    public float ReloadCooldown { get => reloadCooldown; private set => reloadCooldown = value; }
    [SerializeField]
    private float spread;
    public float Spread { get => spread; private set => spread = value; }
}
