using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 시작 값 이상 끝 값 이하의 Int 형 반환
    public static int GenerateIntegerInBound(int startValue, int endValue)
    {
        return Random.Range(startValue, endValue + 1);
    }

    // 0 이상 시작 값과 끝 값의 차 이하의 Int 형 반환
    public static int GenerateIntegerStartFromZero(int startValue, int endValue)
    {
        return Random.Range(0, endValue - startValue + 1);
    }

    // 0.0001% 까지의 확률에 대해 성공, 실패를 반환
    public static bool Chance(float change)
    {
        return Random.Range(0, 1000000) < Mathf.RoundToInt(change * 10000);
    }
}
