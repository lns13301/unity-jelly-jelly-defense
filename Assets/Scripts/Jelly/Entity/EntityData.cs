using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityData
{
    public int level;
    public long experience;
    public float attackSpeed;
    public float attackRange;

    public EntityData(int level, long experience, float attackSpeed, float attackRange)
    {
        this.level = level;
        this.experience = experience;
        this.attackSpeed = attackSpeed;
        this.attackRange = attackRange;
    }

    public static EntityData ValueOfSlimeJelly()
    {
        return new EntityData(1, 0, 0.5f, 2f);
    }
}
