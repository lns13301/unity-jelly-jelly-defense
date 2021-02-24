using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAnimatorController : MonoBehaviour
{
    public List<PanelAnimatorController> others;
    [SerializeField] private Animator animator;
    [SerializeField] private Button button;
    [SerializeField] private List<Sprite> buttonImage;
    public bool isPanelOn;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        isPanelOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelButton()
    {
        if (!isPanelOn)
        {
            OnPanel();
        }
        else
        {
            OffPanel();
        }
    }

    public void OnPanel()
    {
        OffOthers();
        animator.SetTrigger("doShow");
        isPanelOn = true;

        button.image.sprite = buttonImage[1];
    }

    public void OffPanel()
    {
        animator.SetTrigger("doHide");
        isPanelOn = false;

        button.image.sprite = buttonImage[0];
    }

    private void OffOthers()
    {
        foreach (PanelAnimatorController other in others)
        {
            if (other.isPanelOn)
            {
                other.OffPanel();
            }
        }
    }
}
