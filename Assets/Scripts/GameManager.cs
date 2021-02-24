using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        List<bool> unlockState = new List<bool>();
        unlockState.Add(true);
        unlockState.Add(true);
        unlockState.Add(false);
        unlockState.Add(true);
        unlockState.Add(false);
        unlockState.Add(false);
        unlockState.Add(false);
        unlockState.Add(false);
        unlockState.Add(false);
        unlockState.Add(false);
        unlockState.Add(false);
        unlockState.Add(false);
        playerData = new PlayerData(1, 1234, 123456789, unlockState);
        FileIOManager.SavePlayerDataToJson(playerData, "dummy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerData getPlayerData()
    {
        return playerData;
    }

    public void AddJelatin(int count)
    {
        playerData.jelatin += count;

        JelatinStatus.instance.UpdateResourceText(playerData);
    }
}
