using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    public Battle owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision ������Ʈ �ȿ� ������ ������ ������Ʈ�� �����Ѵٸ� - if ���ǹ�
        if(collision.TryGetComponent<Battle>(out Battle battle))
        {
            // �����϶� - battle ������Ʈ�� �ִ� �����϶� ( �����ϴ� ��� : Battle Ŭ������ �� �� �ִ�.)
            owner.Attack(battle);
        }
    }
}
