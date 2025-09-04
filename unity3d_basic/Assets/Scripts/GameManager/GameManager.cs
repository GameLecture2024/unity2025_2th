using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }


    public void GameClear()
    {
        if(IsGameClear())
        {
            //Bus<> I ~~ Event  Raise
            Bus<IGameClearEvent>.Raise(new IGameClearEvent());
        }
    }

    public bool IsGameClear()
    {
        //if() // 게임 클리어를 위한 조건이 필요하다면 해당 if문안에 작성해주세요.
        //{
        //    return false;
        //}

        return true;
    }

    public void GameOver()
    {
        // 게임이 오버되었습니다.
        // Bus<I ~~ Event>.Raise(new ~~());
        Bus<IGameOverEvent>.Raise(new IGameOverEvent());
    }
}
