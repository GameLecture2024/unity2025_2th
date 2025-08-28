using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] NPCInfo npcInfo;

    // 클래스가 부착되어 있는 오브젝트의 다른 컴포넌트를 참조해서 사용할 수 있다.
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    private Vector2 currentTargetPos; // 언제 Stop을 해야 하는가?

    private void Awake()
    {
        // NPC 클래스와 같은 오브젝트에 부착되어 있는 컴포넌트를 GetComponent로 가져와보세요.
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        // 컴포넌트에 데이터를 연결했으면 실제 게임 데이터로 설정해주세요.

        spriteRenderer.sprite = npcInfo.Sprite;
        rigidbody2D.gravityScale = 0;

    }

    private void Start()
    {
        Patrol();
    }

    private void Update()
    {
        // 목적지까지 이동한 후 멈춰라
        Stop();
    }

    public void Patrol()
    {
        // 이동해라 MoveTargetPoint
        MoveTargetPoint();  
    }

    public void Stop()
    {
        // Vector 클래스 안에는 Distance함수가 존재한다.

        //if( ) // 목적지에 도착했으면 멈춰라
        //{
        //    rigidbody2D.velocity = Vector2.zero;
        //}      
    }

    public void WaitTime(float time)
    {

    }

    private void MoveTargetPoint()
    {
        // 속도의 랜덤값 구현
        float moveSpeed = Random.Range((float)npcInfo.MinSpeed, npcInfo.MaxSpeed);

        // 위치의 랜덤값 표현
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * npcInfo.PatrolRadius;

        currentTargetPos = randomPosition;
        // 이동 속도, 이동해야할 위치 현재 위치 (이동해야할 방향)
        // 방향 * 속도 = 이동
        // 두 백터 위치 값과 속도를 사용해서 => 코드를 구현하세요.  이동해야해야할 방향* 속도;
        rigidbody2D.velocity = (randomPosition - (Vector2)transform.position).normalized * moveSpeed;
    }
}
