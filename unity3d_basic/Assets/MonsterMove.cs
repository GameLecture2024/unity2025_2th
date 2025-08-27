using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterMove : MonoBehaviour
{
    // 2d 월드에서 랜덤한 위치로 이동하는 코드를 작성해줘
    // 이동 속도는 얼마인가,
    // 이동 하는 방식은 무엇인가? rigidbody2d를 이용한 물리엔진 방식입니다.
    // 서로 충돌했을 때는 어떤 일인가?

    // MonsterMove 클래스를 생성해보세요.
    // Start함수에 AddComponenet를 사용해서 이 오브젝트에 부착해보세요.
    // MonsterMove 이동속도를 monsterInfo를 이용하여 변경해보세요.

    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigid;
    private Vector2 targetVector;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();    
        // 중앙으로 이동하세요.
        targetVector = SetPositionToCenter();

        rigid.velocity = targetVector.normalized * moveSpeed;
    }

    private Vector2 SetPositionToCenter()
    {
        return Vector2.zero - (Vector2)transform.position;
    }
}
