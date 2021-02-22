using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyData : MonoBehaviour
{
    [SerializeField] private EntityData entityData;

    // Start is called before the first frame update
    void Start()
    {
        entityData = EntityData.ValueOfSlimeJelly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EntityData GetEntityData()
    {
        return entityData;
    }
}
