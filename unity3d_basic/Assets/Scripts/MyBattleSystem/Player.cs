using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Battle
{
    // 충돌체크를 위한 변수
    [SerializeField] AttackChecker attackChecker;

    // 1. 왜 변수를 추가해야 하는가?
    // 2. 변수에 데이터를 초기화할 것인가. <1> 유니티 인스팩터 <2> 코드를 사용해서
    [SerializeField] Animator animator; 

    //private void Start()
    //{
    //    attackChecker = GetComponentInChildren<AttackChecker>();
    //}

    // 애니메이터를 실행하기 위한 컴포넌트 Animator (멤버 변수)


    public override void Attack(Battle other)
    {
        
    }

    public override void Attack()
    {
        base.Attack();

        attackChecker.gameObject.SetActive(true);

        // 공격을 하면서 애니메이션을 실행시키겠다.    
        animator.SetTrigger("Attack");
        // 공격을 하면서 UI Text를 출력시키겠다.

        // 충돌 이벤트를 구현해보겠다.

        // 일정 시간 후에 활성화된 공격이 비활성화된다.

    }

    public override void ShieldUp(int amount)
    {
        base.ShieldUp(amount);

        animator.SetTrigger("ShiledUp");
    }

    public override void Recover(int amount)
    {
        base.Recover(amount);

        animator.SetTrigger("Recover");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    public override void TakeDamage(Battle other)
    {
        base.TakeDamage(other);

        animator.SetTrigger("Hit");
    }
}
