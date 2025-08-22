using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� ����� �����ϴ� ���� ��ǥ�Դϴ�.
// ������ ���õ� ��Ҹ� �����մϴ�.

// ����ȭ (Serialized) : �츮�� ���� ������ Ŭ���� ������ ����Ƽ���� �о�� �� ���� ������, ����Ƽ �ν�����â���� ������ �� ����.
// ����Ƽ�� �츮�� ������ ������ ���� �� �ֵ��� ��ġ�� ���ϸ� �ȴ�.



namespace BattleExample
{
    public class Player : Battle
    {
        [SerializeField] Animator animator;
        public override void Attack(Battle other)
        {
            if (!battleManager.playerTurn) return;

            animator.SetTrigger("Attack");
            other.TakeDamage(this);

            battleManager.TurnChange();
        }

        // SetTrigger ������ �� �ִϸ��̼� �Ķ���� �̸��� �������� ������ ������ �߻��մϴ�.

        public override void Recover(int amount)
        {
            if (!battleManager.playerTurn) return;

            base.Recover(amount);
            animator.SetTrigger("Recover");

            battleManager.TurnChange();
        }

        public override void ShieldUp(int amount)
        {
            if (!battleManager.playerTurn) return;

            base.ShieldUp(amount);
            animator.SetTrigger("ShieldUp");

            battleManager.TurnChange();
        }
    } 
}
