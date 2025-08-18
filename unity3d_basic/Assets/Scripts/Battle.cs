using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleEntity
{
    public int HP;
    public int ATK;
    public int Def;
    public string AttackType;

    public BattleEntity() { }

    public BattleEntity(int hP, int aTK)
    {
        HP = hP;
        ATK = aTK;
    }

    public BattleEntity(int hP, int aTK, int def)
    {
        HP = hP;
        ATK = aTK;
        Def = def;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HpBar;
    public TextMeshProUGUI BattleEntityText;
    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityText.SetText($"ATK : {battleEntity.ATK}, DEF : {battleEntity.Def}");
    }

    public void SetHPBar(int current, int max)
    {
        HpBar.fillAmount = (float)current / max;
    }

}

public class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;

    public int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        // battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);

        Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.Def}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
    }

    // 상대에게 데미지를 받는다 (TakeDamage) :: CurrentHP - (ATK 방어력에따라서 감소)

    // 죽었을 때 로직 처리하기 Die,Death :: CurrentHP 0보다 작아졌을 때 이벤트를 실행한다.

}
