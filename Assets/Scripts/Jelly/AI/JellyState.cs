using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyState : MonoBehaviour
{
    private static string DEFAULT_PATH = "JellyFarm Assets Pack/Animations/";

    [SerializeField] private Animator animator;
    [SerializeField] private List<RuntimeAnimatorController> levelAnimaionController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevelAnimationController(int level)
    {
        animator.runtimeAnimatorController = levelAnimaionController[level - 1];
    }

    private void LoadAnimationController()
    {
        levelAnimaionController.Add(Resources.Load<RuntimeAnimatorController>(DEFAULT_PATH + "Ac1"));
        levelAnimaionController.Add(Resources.Load<RuntimeAnimatorController>(DEFAULT_PATH + "Ac2"));
        levelAnimaionController.Add(Resources.Load<RuntimeAnimatorController>(DEFAULT_PATH + "Ac3"));
    }
}
