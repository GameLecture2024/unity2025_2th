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
                // ��� ���� ȿ����, ����Ʈ, �ִϸ��̼�... �̺�Ʈ ����
                currentHP = 0;
                Death();
            }
            else
            {
                // �ǰ� ���� ȿ����, ����Ʈ, �ִϸ��̼� .... �̺�Ʈ ����
            }

            return currentHP; 
        }
        private set
        {
            if (value > battleEntity.HP) value = battleEntity.HP;
                
            currentHP = value; 
        } 
    } // Battle Ŭ�������� ���� ü�� ������ ������ �� �ִ�.


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

    // ��뿡�� �������� �޴´� (TakeDamage) :: CurrentHP - (ATK ���¿����� ����)

    // �������� �Ծ���.
    public void TakeDamage(Battle other)
    {
        int FinalDamage = (other.battleEntity.ATK - battleEntity.Def);
        if (FinalDamage <= 0) FinalDamage = 1;

        CurrentHP -= FinalDamage; // ����� ���ݷ� 

        Debug.Log($"���������� : {FinalDamage}, �������� ���ݷ� : {other.battleEntity.ATK}, ���� : {battleEntity.Def}");
        
    }

    // �׾��� �� ���� ó���ϱ� Die,Death :: CurrentHP 0���� �۾����� �� �̺�Ʈ�� �����Ѵ�.

    public void Death()
    {
        // ��� �̺�Ʈ ȣ��
        Debug.Log($"����߽��ϴ�. ���� ü�� : {currentHP}");
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
