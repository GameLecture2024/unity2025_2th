using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 1. 동전을 먹었을 때 작동하라

// 2. 동전이 생성이 되었으면 얼마 만큼의 동전이 현재 게임 씬에 존재하는지 파악하는 코드를 작성해라.

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int SpawnCount;  // 한번에 생성할 동전의 갯수
    public List<Coin> spawnedList = new();
    public int SpawnedCount; // Scene에 생성된 코인의 수


    public void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent += HandleSpawnCoin;
    }

    public void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent -= HandleSpawnCoin;
    }

    // ICoinSpawnEvent가 Coin 정보를 저장하도록 Coin 변수를 선언해보세요.
    // Raise 함수를 실행할 때 Coin 정보를 전달하도록 수정해보세요.
    private void HandleSpawnCoin(ICoinSpawnEvent evt)
    {
        // Coin 객체가 얼마 만큼 저장되어 있는가? 자료구조로 저장을 하겠다.        
        spawnedList.Add(evt.Coin);
        SpawnedCount++;
    }

    // 게임에 플레이어가 코인을 획득한 경우에
    private void HandleGetCoin(IGetCoinEvent evt)
    {
        // 코인을 생성하고 싶습니다. SpawnCount

        // 획득한 코인은 리스트에서 제거해주세요.
        spawnedList.Remove(evt.Coin);
        SpawnedCount--;
        // 동전이 생성된 갯수가 일정 이하 일때만 생성하라
        if (SpawnCount > 2) { return; }

        for(int i=0; i<SpawnCount; i++)
        {
            Vector2 randomSpawnPos = UnityEngine.Random.insideUnitCircle * 10;
            Instantiate(CoinPrefab, Vector3.zero + (Vector3)randomSpawnPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(Vector3.zero, 10);
    }
}
