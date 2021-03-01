using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static float MIN_MOVEMENT = 1f;
    private static float MAX_MOVEMENT = 1f;
    private static float CORRECTION_Y_SPEED = 0.6f;
    private static string WALK_STATE = "isWalk";

    [SerializeField] private Animator animator;

    [SerializeField] private Vector3 movementVelocity;

    [SerializeField] private float speed;
    [SerializeField] private bool isThinking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isThinking = false;
        StartCoroutine("MoveState");
        movementVelocity = createMovementVector(speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveState()
    {
        while (!isThinking)
        {
            Move();
            yield return null;
        }
    }

/*    IEnumerator ThinkState()
    {
        while (true)
        {
            yield return null; // 이동 상태로 변경
            isThinking = false;
            movementVelocity = createMovementVector(speed);
            FlipX(movementVelocity);
            StartCoroutine("MoveState");
            animator.SetBool(WALK_STATE, true);
        }
    }*/

    private void FlipX(Vector2 movementVelocity)
    {
        if (movementVelocity.x >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Move()
    {
        Vector3 position = transform.position;
        Quaternion quaternion = transform.rotation;

        position = transform.position;

        transform.SetPositionAndRotation(
            new Vector3(position.x + (movementVelocity.x * Time.deltaTime), position.y, position.x), quaternion); // 이동

        animator.SetBool(WALK_STATE, true);
    }

    private Vector2 createMovementVector(float speed)
    {
        return new Vector2(Random.Range(MIN_MOVEMENT, MAX_MOVEMENT) * speed, Random.Range(MIN_MOVEMENT, MAX_MOVEMENT) * CORRECTION_Y_SPEED * speed);
    }

    private float CreateWaitingTime(float startValue, float endValue)
    {
        return Random.Range(startValue, endValue);
    }
}
