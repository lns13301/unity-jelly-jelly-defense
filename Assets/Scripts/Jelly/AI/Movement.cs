using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private static float START_WAITING_TIME = 2;
    private static float END_WAITING_TIME = 4;
    private static float MIN_MOVEMENT = 0.5f;
    private static float MAX_MOVEMENT = 1.5f;
    private static float CORRECTION_Y_SPEED = 0.6f;
    private static float CORRECTION_BONUS_SPEED = 0.1f; // 경계 충돌 시 방향을 변경하고 더 빠른속도로 벽과 멀어지기 위한 속도 보너스
    private static string WALK_STATE = "isWalk";
    private static string TOUCH_STATE = "doTouch";

    [SerializeField] private Animator animator;

    [SerializeField] private Vector3 movementVelocity;

    [SerializeField] private Vector3 movementBorderLeftBottom;
    [SerializeField] private Vector3 movementBorderRightTop;
    [SerializeField] private Vector3 resetPosition;

    [SerializeField] private float speed;
    [SerializeField] private bool isThinking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isThinking = true;
        StartCoroutine("ThinkState");
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

    IEnumerator ThinkState()
    {
        WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(CreateWaitingTime(START_WAITING_TIME, END_WAITING_TIME));

        while (true)
        {
            yield return waitForSecondsRealtime; // 이동 상태로 변경
            isThinking = false;
            movementVelocity = ChangeVectorDirection(createMovementVector(speed));
            FlipX(movementVelocity);
            StartCoroutine("MoveState");
            animator.SetBool(WALK_STATE, true);

            yield return waitForSecondsRealtime; // 생각 상태로 변경
            isThinking = true;
            animator.SetBool(WALK_STATE, false);
        }
    }

    public void TouchState()
    {
        isThinking = true;
        StopCoroutine("ThinkState");
        animator.SetBool(WALK_STATE, false);
        animator.SetTrigger(TOUCH_STATE);
        StartCoroutine("ThinkState");
    }

    private void Move()
    {
        Vector3 position = transform.position;
        Quaternion quaternion = transform.rotation;

        NegativeBorderCorrection(); // 경계 초과 시 이동 방향 변경

        position = transform.position;

        transform.SetPositionAndRotation(
            new Vector3(position.x + (movementVelocity.x * Time.deltaTime), position.y + (movementVelocity.y * Time.deltaTime), position.x), quaternion); // 이동
    }

    private void Move(Vector2 speed)
    {
        Vector3 position = transform.position;
        Quaternion quaternion = transform.rotation;

        NegativeBorderCorrection(); // 경계 초과 시 이동 방향 변경

        position = transform.position;

        transform.SetPositionAndRotation(
            new Vector3(position.x + (speed.x * Time.deltaTime), position.y + (speed.y * Time.deltaTime), position.x), quaternion); // 이동
    }

    // 경계를 넘어가면 이동 값을 역전 시킴
    private void NegativeBorderCorrection()
    {
        if (transform.position.x > movementBorderRightTop.x && movementVelocity.x > 0)
        {
            movementVelocity = new Vector3(-(movementVelocity.x + CORRECTION_BONUS_SPEED), movementVelocity.y, movementVelocity.z);
            FlipX(movementVelocity);
        }
        else if (transform.position.x < movementBorderLeftBottom.x && movementVelocity.x < 0)
        {
            movementVelocity = new Vector3(-(movementVelocity.x - CORRECTION_BONUS_SPEED), movementVelocity.y, movementVelocity.z);
            FlipX(movementVelocity);
        }

        if (transform.position.y > movementBorderRightTop.y && movementVelocity.y > 0)
        {
            movementVelocity = new Vector3(movementVelocity.x, -(movementVelocity.y + CORRECTION_BONUS_SPEED), movementVelocity.z);
        }
        else if (transform.position.y < movementBorderLeftBottom.y && movementVelocity.y < 0)
        {
            movementVelocity = new Vector3(movementVelocity.x, -(movementVelocity.y - CORRECTION_BONUS_SPEED), movementVelocity.z);
        }
    }

    private Vector2 createMovementVector(float speed)
    {
        return new Vector2(Random.Range(MIN_MOVEMENT, MAX_MOVEMENT) * speed, Random.Range(MIN_MOVEMENT, MAX_MOVEMENT) * CORRECTION_Y_SPEED * speed);
    }

    // 이동 방향 설정
    private Vector2 ChangeVectorDirection(Vector2 vector2)
    {
        if (RandomGenerator.Chance(50))
        {
            vector2 = new Vector2(-vector2.x, vector2.y);
        }

        if (RandomGenerator.Chance(50))
        {
            vector2 = new Vector2(vector2.x, -vector2.y);
        }

        return vector2;
    }

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

    private float CreateWaitingTime(float startValue, float endValue)
    {
        return Random.Range(startValue, endValue);
    }
}
