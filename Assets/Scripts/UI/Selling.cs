using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selling : MonoBehaviour
{
    private static string SELLING_SOUND = "Sell";

    public static Selling instance;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private JellyData selectedJelly;
    public bool isSellingMode;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerData = GameManager.instance.getPlayerData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void registerJelly(JellyData jellyData)
    {
        selectedJelly = jellyData;
    }

    public void Sell()
    {
        SoundManager.instance.PlayOneShowSoundFindByName(SELLING_SOUND);

        if (isSellingMode && selectedJelly != null)

        playerData.money += selectedJelly.GetEntityData().level * 10000;
        Destroy(selectedJelly.gameObject);

        selectedJelly = null;
        isSellingMode = false;

        GoldStatus.instance.UpdateResourceText(playerData);
    }

    public void OnPointer()
    {
        isSellingMode = true;
    }

    public void ExitPointer()
    {
        isSellingMode = false;
    }
}
