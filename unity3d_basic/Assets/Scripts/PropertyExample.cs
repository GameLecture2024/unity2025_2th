using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyExample 
{
    // 멤버 변수, 멤버 함수

    private int hp; // 
    
    // 프로퍼티 사용 형태 (1)
    public int HP { get; set; }
    public int ATK { get; set; }
    // 프로퍼티 사용 형태 (2)
    public int HP2 {
        get 
        {
            if (hp <= 0)
            {
                hp = 0;
                // 플레이어가 사망했습니다!
            }
            return hp; 
        }
        set 
        {
            hp = value; 
        } 
    }

    // 프로퍼티 사용법 3
    public int DEF { get; set; } // 외부에서 값을 변경하지 마세요.

    public int MaxLevel { get; private set; } // 게임 시작할 때 최대 레벨을 설정. 다른 클래스에서 변경할 수 없도록 설정한다.


    /*
     *  프로퍼티(Property)
     *  사용법 : 변수 선언 public (타입) (변수 이름) 첫글자를 대문자로 작성하는 것이 이름 규칙입니다.
     *  public int HP {get; set;}
     */


    /// <summary>
    /// hp를 절반으로 변경해주는 코드입니다. 반드시 이 함수를 이용해서 HP를 조절해주세요.
    /// </summary>
    public void UseThisFunction()
    {
        // hp가 어떤 시스템에 의해서 변경됩니다.

        hp /= 2;
    }
}

