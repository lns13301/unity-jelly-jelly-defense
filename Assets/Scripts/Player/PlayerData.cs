using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;

    public long jelatin;
    public long money;

    public PlayerData(int level, long jelatin, long money)
    {
        this.level = level;
        this.jelatin = jelatin;
        this.money = money;
    }
}
