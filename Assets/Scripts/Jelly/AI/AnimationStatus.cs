using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStatus: MonoBehaviour
{
    public Vector3 movementBorder;
    public Vector3 resetPosition;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum AnimationState
{
    NONE,
    IDLE,
    JUMP,
    PICK
}
