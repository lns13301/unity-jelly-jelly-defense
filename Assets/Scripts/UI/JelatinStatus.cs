using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JelatinStatus : MonoBehaviour
{
    public static JelatinStatus instance;

    public PlayerData playerData;
    public Text resourceText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateResourceText(GameManager.instance.getPlayerData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateResourceText(PlayerData playerData)
    {
        resourceText.text = NumberFormat.ChangeNumberFormat(playerData.jelatin);
    }
}
