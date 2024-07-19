using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGem : MonoBehaviour,iCollectable
{
    public float lifeRegen;
    public void Collect()
    {
        PlayerControler.player.CurrentHealth+=lifeRegen;
        Destroy(gameObject);
    }
}
