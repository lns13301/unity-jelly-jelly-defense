using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerData = new PlayerData(1, 1234, 123456789);
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
