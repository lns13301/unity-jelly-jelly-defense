using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private static string ESCAPE = "escape";

    public List<PanelAnimatorController> others;
    public GameObject optionPanel;
    public bool isPanelOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectEscape();
    }

    public void DetectEscape()
    {
        if (Input.GetKeyDown(ESCAPE))
        {
            if (optionPanel.activeSelf)
            {
                OffPanel();
            }
            else
            {
                OnPanel();
            }
        }
    }

    public void OnPanel()
    {
        if (OffIfOthersOn())
        {
            return;
        }

        optionPanel.SetActive(true);
        isPanelOn = true;
        Time.timeScale = 0;
    }

    public void OffPanel()
    {
        optionPanel.SetActive(false);
        isPanelOn = false;
        Time.timeScale = 1;
    }

    public bool OffIfOthersOn()
    {
        foreach (PanelAnimatorController other in others)
        {
            if (other.isPanelOn)
            {
                other.OffPanel();
                return true;
            }
        }

        return false;
    }
}
