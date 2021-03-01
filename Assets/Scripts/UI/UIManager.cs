using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public List<PanelAnimatorController> animatorControllers;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OffAllUI()
    {
        foreach (PanelAnimatorController other in animatorControllers)
        {
            if (other.isPanelOn)
            {
                other.OffPanel();
            }
        }
    }
}
