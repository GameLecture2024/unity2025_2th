using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모의 함수를 가져와서 사용하는 방법을 학습합니다.
// 부모의 함수를 다시 정의한다(재정의) override

public class Monster : Battle
{
    public override void Attack(Battle other)
    {
        if (battleManager.playerTurn) return;

        other.TakeDamage(this);
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
