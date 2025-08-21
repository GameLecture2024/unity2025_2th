using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �θ��� �Լ��� �����ͼ� ����ϴ� ����� �н��մϴ�.
// �θ��� �Լ��� �ٽ� �����Ѵ�(������) override

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
