using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIOManager
{
    private static bool isMobile = false;
    private static Product product;

    [ContextMenu("To Json Data")]
    public static void SavePlayerDataToJsonAESCrypt(PlayerData playerData, string saveFileName)
    {
        // Debug.Log("���� ����");

        string jsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(SaveOrLoad(isMobile, true, saveFileName), AESCrypto.AESEncrypt128(jsonData));
    }

    [ContextMenu("To Json Data")]
    public static void SavePlayerDataToJson(PlayerData playerData, string saveFileName)
    {
        // Debug.Log("���� ����");

        string jsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(SaveOrLoad(isMobile, true, saveFileName), jsonData);
    }

    [ContextMenu("From Json Data")]
    public static void LoadPlayerDataFromJsonAESCrypt(PlayerData playerData, string saveFileName)
    {
        try
        {
            Debug.Log("�÷��̾� ���� �ε� ����");
            string jsonData = File.ReadAllText(SaveOrLoad(isMobile, false, saveFileName));
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);

            // ���� ���� �� ��������Ʈ �̹��� �ڵ尡 ����Ǵ� ���� ����
/*            for (int i = 0; i < playerData.items.Count; i++)
            {
                playerData.items[i] = ItemDatabase.instance.makeItem(ItemDatabase.instance.findItemByCode(playerData.items[i].code), playerData.items[i].count);
            }*/
        }
        catch (FileNotFoundException)
        {
            Debug.Log("�÷��̾� ���̺����� �ε� ����");

            string jsonData = JsonUtility.ToJson(playerData, true);

            File.WriteAllText(SaveOrLoad(isMobile, false, saveFileName), jsonData);
            LoadPlayerDataFromJson(playerData, saveFileName);
        }
    }

    [ContextMenu("From Json Data")]
    public static void LoadPlayerDataFromJson(PlayerData playerData, string saveFileName)
    {
        try
        {
            Debug.Log("�÷��̾� ���� �ε� ����");
            string jsonData = File.ReadAllText(SaveOrLoad(isMobile, false, saveFileName));
            playerData = JsonUtility.FromJson<PlayerData>(AESCrypto.AESDecrypt128(jsonData));

            // ���� ���� �� ��������Ʈ �̹��� �ڵ尡 ����Ǵ� ���� ����
            /*            for (int i = 0; i < playerData.items.Count; i++)
                        {
                            playerData.items[i] = ItemDatabase.instance.makeItem(ItemDatabase.instance.findItemByCode(playerData.items[i].code), playerData.items[i].count);
                        }*/
        }
        catch (FileNotFoundException)
        {
            Debug.Log("�÷��̾� ���̺����� �ε� ����");

            if (product == Product.TEST)
            {

            }
            else
            {

            }

            // playerData.isTestVersion = isTestVersion;

            string jsonData = JsonUtility.ToJson(playerData, true);

            File.WriteAllText(SaveOrLoad(isMobile, false, saveFileName), AESCrypto.AESEncrypt128(jsonData));
            LoadPlayerDataFromJson(playerData, saveFileName);
        }
    }

    public static string SaveOrLoad(bool isMobile, bool isSave, string fileName)
    {
        if (isSave)
        {
            if (isMobile)
            {
                // ����� ����
                return Path.Combine(Application.persistentDataPath, fileName + ".json");
            }
            else
            {
                // pc ����
                return Path.Combine(Application.dataPath, fileName + ".json");
            }
        }
        else
        {
            if (isMobile)
            {
                // ����� �ε�
                return Path.Combine(Application.persistentDataPath, fileName + ".json");
            }
            else
            {
                // pc �ε�
                return Path.Combine(Application.dataPath, fileName + ".json");
            }
        }
    }
}

public enum Product
{
    TEST,
    NORMAL,
    PRE_UPDATE
}
