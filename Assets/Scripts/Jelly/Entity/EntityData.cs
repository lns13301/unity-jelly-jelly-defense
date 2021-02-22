using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityData
{
    public int level;
    public long experience;

    public EntityData(int level, long experience)
    {
        this.level = level;
        this.experience = experience;
    }

    public static EntityData ValueOfSlimeJelly()
    {
        return new EntityData(1, 0);
    }
}
