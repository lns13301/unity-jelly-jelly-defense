using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldJellyShop : MonoBehaviour
{
    private static Vector3 DEFAULT_POSTION = new Vector3(30, 0, 10);

    [SerializeField] private GameObject jelly;
    public Transform jellyParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseJelly()
    {
        // µ· Ã¼Å© ·ÎÁ÷
        UIManager.instance.OffAllUI();
        summonJelly();
    }

    public void summonJelly()
    {
        GameObject go = Instantiate(jelly, DEFAULT_POSTION, Quaternion.identity);
        go.transform.parent = jellyParent;
    }
}
