using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모의 함수를 가져와서 사용하는 방법을 학습합니다.
// 부모의 함수를 다시 정의한다(재정의) override

namespace BattleExample
{
    public class Monster : Battle
    {
        [SerializeField] Animator animator;

        public override void Attack(Battle other)
        {
            if (battleManager.playerTurn) return;

            //animator.SetTrigger("Attack");         // 공격 애니메이션 실행
            other.TakeDamage(this);                // 데미지 로직 실행
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
