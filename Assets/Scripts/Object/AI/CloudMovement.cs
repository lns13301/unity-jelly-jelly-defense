using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public Vector3 movementBorder;
    public Vector3 resetPosition;

    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 position = GetComponent<Transform>().position;
        Quaternion quaternion = GetComponent<Transform>().rotation;
        
        GetComponent<Transform>().SetPositionAndRotation(ResetPosition(position), quaternion); // 경계 초과 시 초기화 위치로 보정

        position = GetComponent<Transform>().position;

        GetComponent<Transform>().SetPositionAndRotation(new Vector3(position.x + (speed * Time.deltaTime), position.y, position.z), quaternion); // 이동
    }

    private Vector3 ResetPosition(Vector3 position)
    {
        if (position.x > movementBorder.x)
        {
            return resetPosition;
        }

        return position;
    }
}
