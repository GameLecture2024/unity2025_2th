using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �θ��� �Լ��� �����ͼ� ����ϴ� ����� �н��մϴ�.
// �θ��� �Լ��� �ٽ� �����Ѵ�(������) override

namespace BattleExample
{
    public class Monster : Battle
    {
        [SerializeField] Animator animator;

        public override void Attack(Battle other)
        {
            if (battleManager.playerTurn) return;

            //animator.SetTrigger("Attack");         // ���� �ִϸ��̼� ����
            other.TakeDamage(this);                // ������ ���� ����
        }

        public override void Recover(int amount)
        {
            if (battleManager.playerTurn) return;

            base.Recover(amount);
        }

        public override void ShieldUp(int amount)
        {
            if (battleManager.playerTurn) return;

            base.ShieldUp(amount);
        }
    } 
}
