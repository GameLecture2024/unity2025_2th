using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Battle
{
    // �浹üũ�� ���� ����
    [SerializeField] AttackChecker attackChecker;

    // 1. �� ������ �߰��ؾ� �ϴ°�?
    // 2. ������ �����͸� �ʱ�ȭ�� ���ΰ�. <1> ����Ƽ �ν����� <2> �ڵ带 ����ؼ�
    [SerializeField] Animator animator; 

    //private void Start()
    //{
    //    attackChecker = GetComponentInChildren<AttackChecker>();
    //}

    // �ִϸ����͸� �����ϱ� ���� ������Ʈ Animator (��� ����)


    public override void Attack(Battle other)
    {
        
    }

    public override void Attack()
    {
        base.Attack();

        attackChecker.gameObject.SetActive(true);

        // ������ �ϸ鼭 �ִϸ��̼��� �����Ű�ڴ�.    
        animator.SetTrigger("Attack");
        // ������ �ϸ鼭 UI Text�� ��½�Ű�ڴ�.

        // �浹 �̺�Ʈ�� �����غ��ڴ�.

        // ���� �ð� �Ŀ� Ȱ��ȭ�� ������ ��Ȱ��ȭ�ȴ�.

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
