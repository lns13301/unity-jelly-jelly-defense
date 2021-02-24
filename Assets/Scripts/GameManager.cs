using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static string BACKGROUND_MUSIC_DEFAULT = "BGM";

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
        playerData = new PlayerData(1, 12345, 123456789, unlockState);
        FileIOManager.SavePlayerDataToJson(playerData, "dummy");

        Invoke("PlayBGM", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM()
    {
        SoundManager.instance.PlayOneShowSoundFindByName(BACKGROUND_MUSIC_DEFAULT);
    }

    public void AddJelatin(int count)
    {
        playerData.jelatin += count;

        JelatinStatus.instance.UpdateResourceText(playerData);
    }

    public PlayerData getPlayerData()
    {
        return playerData;
    }
}
