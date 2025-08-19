using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyExample 
{
    // ��� ����, ��� �Լ�

    private int hp; // 
    
    // ������Ƽ ��� ���� (1)
    public int HP { get; set; }
    public int ATK { get; set; }
    // ������Ƽ ��� ���� (2)
    public int HP2 {
        get 
        {
            if (hp <= 0)
            {
                hp = 0;
                // �÷��̾ ����߽��ϴ�!
            }
            return hp; 
        }
        set 
        {
            hp = value; 
        } 
    }

    // ������Ƽ ���� 3
    public int DEF { get; set; } // �ܺο��� ���� �������� ������.

    public int MaxLevel { get; private set; } // ���� ������ �� �ִ� ������ ����. �ٸ� Ŭ�������� ������ �� ������ �����Ѵ�.


    /*
     *  ������Ƽ(Property)
     *  ���� : ���� ���� public (Ÿ��) (���� �̸�) ù���ڸ� �빮�ڷ� �ۼ��ϴ� ���� �̸� ��Ģ�Դϴ�.
     *  public int HP {get; set;}
     */


    /// <summary>
    /// hp�� �������� �������ִ� �ڵ��Դϴ�. �ݵ�� �� �Լ��� �̿��ؼ� HP�� �������ּ���.
    /// </summary>
    public void UseThisFunction()
    {
        // hp�� � �ý��ۿ� ���ؼ� ����˴ϴ�.

        hp /= 2;
    }
}

