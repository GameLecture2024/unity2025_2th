using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 모든 클래스가 접근할 수 있게 해준다.
    // 그런데 ScoreManager2개 이상 존재한다면, 어떤 ScoreManager에 접근해야 하나요?
    // 하나만 존재하도록 코드를 설정해줘야 한다.
    public static ScoreManager Instance;

    private void Awake()
    {

        // 이 클래스가 단독으로 존재해주도록 조건을 만든다.
        // SingleTon 패턴

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int Score;
    public int BestScore;
    public const string _BESTSCORE = "BestScore";
    // 어딘 가의 장소에 다가(숨겨진) 데이터를 저장해둔다.
    // C드라이브 특정 장소를 주소를 가져와서, 그 주소에 파일을 생성해서 데이터를 저장한다.
    // 앱 데이터 동기화 초기화 폴더 경로, Android/Data/Program/....
    // 만들어진 저장 기능을 불러오겠다.
    public void SaveScore(int currentScore)
    {
        if(currentScore < BestScore) { return; }

        PlayerPrefs.SetInt(_BESTSCORE, currentScore);
    }

    // 저장해둔 장소로 부터 데이터를 불러온다.
    // 게임을 처음 시작할 때는 BestScore 데이터가 존재하지 않는다.
    // 존재하지 않는 데이터를 참조하려고 하면 에러가 발생한다.
    public void LoadScore()
    {
        if(PlayerPrefs.HasKey(_BESTSCORE)) // 플레이어Prefs의 BestScore값이 존재하나요?
        {
            BestScore = PlayerPrefs.GetInt(_BESTSCORE);
        }
        else
        {
            BestScore = 0;
        }
       
    }
}
