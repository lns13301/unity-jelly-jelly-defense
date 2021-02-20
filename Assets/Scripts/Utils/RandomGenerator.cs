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

    // ���� �� �̻� �� �� ������ Int �� ��ȯ
    public static int GenerateIntegerInBound(int startValue, int endValue)
    {
        return Random.Range(startValue, endValue + 1);
    }

    // 0 �̻� ���� ���� �� ���� �� ������ Int �� ��ȯ
    public static int GenerateIntegerStartFromZero(int startValue, int endValue)
    {
        return Random.Range(0, endValue - startValue + 1);
    }

    // 0.0001% ������ Ȯ���� ���� ����, ���и� ��ȯ
    public static bool Chance(float change)
    {
        return Random.Range(0, 1000000) < Mathf.RoundToInt(change * 10000);
    }
}
