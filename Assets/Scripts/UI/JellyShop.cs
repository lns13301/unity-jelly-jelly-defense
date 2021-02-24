using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyShop : MonoBehaviour
{
    private static Vector3 SPAWN_POSITION = new Vector3(0, 0, 0);
    private static string JELLY_PARENT_NAME = "Jellies";

    private GameObject lockGroup;
    private GameObject unlockGroup;

    [SerializeField] private int pageIndex;
    [SerializeField] private List<Sprite> jellySprites;
    [SerializeField] private List<string> jellyNames;
    [SerializeField] private List<long> jellyPrices;
    [SerializeField] private List<long> jellyUnlockPrices;

    [SerializeField] private PlayerData playerData;

    public Text indexText;

    public Image unlockSprite;
    public Image lockSprite;

    public Text unlockNameText;
    public Text unlockJellyText;

    public Text unlockPrice;
    public Text lockPrice;

    [SerializeField] public List<GameObject> jellies;
    private Transform jellyParent;

    // Start is called before the first frame update
    void Start()
    {
        lockGroup = transform.GetChild(0).gameObject;
        unlockGroup = transform.GetChild(1).gameObject;
        jellyParent = GameObject.Find(JELLY_PARENT_NAME).transform;

        playerData = GameManager.instance.getPlayerData();

        PageUp();
        PageDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PageUp()
    {
        if (pageIndex == jellySprites.Count - 1)
        {
            return;
        }

        indexText.text = "#" + (++pageIndex + 1);

        changeItem();
    }

    public void PageDown()
    {
        if (pageIndex == 0)
        {
            return;
        }

        indexText.text = "#" + (--pageIndex + 1);

        changeItem();
    }

    private void changeItem()
    {
        changeLockState();

        unlockSprite.sprite = jellySprites[pageIndex];
        lockSprite.sprite = jellySprites[pageIndex];
        unlockNameText.text = jellyNames[pageIndex];
        unlockPrice.text = NumberFormat.ChangeNumberFormat(jellyPrices[pageIndex]);
        lockPrice.text = NumberFormat.ChangeNumberFormat(jellyUnlockPrices[pageIndex]);
    }

    public void changeLockState()
    {
        lockGroup.SetActive(!playerData.unlockState[pageIndex]);
        unlockGroup.SetActive(playerData.unlockState[pageIndex]);
    }

    public void PurchaseItem()
    {
        long price = NumberFormat.ChangeFormatToLong(unlockPrice.text);

        if (playerData.money < price)
        {
            return;
        }

        playerData.spendMoney(price);
        summonJelly(pageIndex);
    }

    public void UnlockItem()
    {
        long price = NumberFormat.ChangeFormatToLong(lockPrice.text);

        if (playerData.jelatin < price)
        {
            return;
        }

        playerData.unlockState[pageIndex] = true;
        playerData.spendJelatin(price);
        changeLockState();
    }

    public void summonJelly(int index)
    {
        GameObject go = Instantiate(jellies[index], SPAWN_POSITION, Quaternion.identity);
        go.transform.parent = jellyParent;
    }
}
