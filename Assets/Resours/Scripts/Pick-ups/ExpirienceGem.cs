using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Предмет гем опыта. Дает опыт при подборе а так же увеличивает счет.
public class ExpirienceGem : MonoBehaviour, iCollectable
{
    public int expirienceGranted;
    public void Collect()
    {
        GameManager.gameManager.Score += expirienceGranted;
        PlayerControler.player.IncreaseXp(expirienceGranted);
        Destroy(gameObject);
    }
}
