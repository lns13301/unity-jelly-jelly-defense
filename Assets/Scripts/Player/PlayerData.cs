using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;

    public long jelatin;
    public long money;

    public List<bool> unlockState;

    public PlayerData(int level, long jelatin, long money, List<bool> unlockState)
    {
        this.level = level;
        this.jelatin = jelatin;
        this.money = money;
        this.unlockState = unlockState;
    }

    public void gainMoney(long gain)
    {
        money += gain;
        GoldStatus.instance.UpdateResourceText(this);
    }

    public void gainJelatin(long gain)
    {
        jelatin += gain;
        JelatinStatus.instance.UpdateResourceText(this);
    }

    public void spendMoney(long spend)
    {
        money -= spend;
        GoldStatus.instance.UpdateResourceText(this);
    }

    public void spendJelatin(long spend)
    {
        jelatin -= spend;
        JelatinStatus.instance.UpdateResourceText(this);
    }
}
