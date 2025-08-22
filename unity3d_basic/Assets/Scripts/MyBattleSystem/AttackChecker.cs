using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    public Battle owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision 오브젝트 안에 공격이 가능한 컴포넌트가 존재한다면 - if 조건문
        if(collision.TryGetComponent<Battle>(out Battle battle))
        {
            // 공격하라 - battle 컴포넌트에 있는 공격하라 ( 공격하는 대상 : Battle 클래스를 알 수 있다.)
            owner.Attack(battle);
        }
    }
}
