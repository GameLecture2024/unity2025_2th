using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 기능을 구현하는 것이 목표입니다.
// 전투와 관련된 요소를 정의합니다.

// 직렬화 (Serialized) : 우리가 직접 정의한 클래스 정보를 유니티에서 읽어올 수 없기 때문에, 유니티 인스팩터창에서 노출할 수 없다.
// 유니티가 우리가 정의한 정보를 읽을 수 있도록 조치를 취하면 된다.



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

        // SetTrigger 실행할 때 애니메이션 파라미터 이름과 동일하지 않으면 에러가 발생합니다.

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
