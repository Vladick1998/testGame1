using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableobjects", menuName = "ScriptableObjects/Character")]
public class PlayerScriptableObjet : ScriptableObject
{
    [SerializeField]
    private GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }
    [SerializeField]
    private float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }
    [SerializeField]
    private float xpToLevelUp;// оличество опыта дл€ получени€ следующего уровн€
    public float XpToLevelUp { get => xpToLevelUp; private set => xpToLevelUp = value; }
    [SerializeField]
    private float xpToLevelUpMyltiplier;//ћножитель опыта дл€ получени€ следующего уровн€
    public float XpToLevelUpMultiplier { get => xpToLevelUpMyltiplier; private set => xpToLevelUpMyltiplier = value; }
    [SerializeField]
    private float might;
    public float Might { get => might; private set => might = value; }

}
