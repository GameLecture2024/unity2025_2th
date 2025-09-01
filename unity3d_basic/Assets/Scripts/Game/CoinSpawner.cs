using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 1. 동전을 먹었을 때 작동하라

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int SpawnCount;

    public void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }

    public void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    // 게임에 플레이어가 코인을 획득한 경우에
    private void HandleGetCoin(IGetCoinEvent evt)
    {        
        // 코인을 생성하고 싶습니다. SpawnCount

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
