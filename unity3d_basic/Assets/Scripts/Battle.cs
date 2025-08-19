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
    public BattleManager battleManager;

    public bool IsPlayer;
    
    public int CurrentHP {
        get {
            if(currentHP <=0)
            {
                // 사망 시의 효과음, 이펙트, 애니메이션... 이벤트 실행
                currentHP = 0;
                Death();
            }
            else
            {
                // 피격 시의 효과음, 이펙트, 애니메이션 .... 이벤트 실행
            }

            return currentHP; 
        }
        private set
        {
            if (value > battleEntity.HP) value = battleEntity.HP;
                
            currentHP = value; 
        } 
    } // Battle 클래스에서 현재 체력 변수를 수정할 수 있다.


    [SerializeField] private int currentHP;


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

    // 데미지를 입었다.
    public void TakeDamage(Battle other)
    {
        int FinalDamage = (other.battleEntity.ATK - battleEntity.Def);
        if (FinalDamage <= 0) FinalDamage = 1;

        CurrentHP -= FinalDamage; // 상대의 공격력 

        Debug.Log($"최종데미지 : {FinalDamage}, 공격자의 공격력 : {other.battleEntity.ATK}, 방어력 : {battleEntity.Def}");
        
    }

    // 죽었을 때 로직 처리하기 Die,Death :: CurrentHP 0보다 작아졌을 때 이벤트를 실행한다.

    public void Death()
    {
        // 사망 이벤트 호출
        Debug.Log($"사망했습니다. 현재 체력 : {currentHP}");
    }

    public void Attack()
    {

    }

    public void Recover(int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;

        CurrentHP += amount;
    }

    public void ShieldUp(int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;

        battleEntity.Def += amount;
        battleUI.SetBattleUI(battleEntity);
    }

}
