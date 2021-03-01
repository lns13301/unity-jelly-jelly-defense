using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject fieldPanel;

    public Camera homeCamera;
    public Camera fieldCamera;

    // Start is called before the first frame update
    void Start()
    {
        fieldCamera.gameObject.SetActive(false);
        fieldPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneToHome()
    {
        homePanel.SetActive(true);
        fieldPanel.SetActive(false);
        homeCamera.gameObject.SetActive(true);
        fieldCamera.gameObject.SetActive(false);
    }

    public void ChangeSceneToField()
    {
        homePanel.SetActive(false);
        fieldPanel.SetActive(true);
        homeCamera.gameObject.SetActive(false);
        fieldCamera.gameObject.SetActive(true);
    }
}
