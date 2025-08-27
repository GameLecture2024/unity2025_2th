using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Example;
public class MonsterSpawner : MonoBehaviour
{
    // 특정 시점, 특정 이벤트가 발생되고 나서 몬스터를 생성하고 싶다.

    [Header("몬스터 생성 정보")]
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject[] spawnMonsters;
    [SerializeField] Monster[] monsterInfos;


    [SerializeField] int spawnCount = 5;
    [SerializeField] float spawnIntervalTime = 0.75f;
    private Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Spawn();
        }
    }

    /// <summary>
    /// 게임 월드에 특정 위치에 몬스터를 생성하는데, 몇 마리를 생성할까
    /// 한번에 몬스터가 등장할 것인가, 시간 걸쳐서 서서히 생성할 것인가
    /// 유니티에서 함수 이름이 Spawn이고 위의 두줄의 기능을 하는 함수를 만들어줘.
    /// </summary>
    public void Spawn()
    {
        if(spawnCoroutine != null)
        {
            StopCoroutine(SpawnCoroutine());
        }

        spawnCoroutine = StartCoroutine(SpawnCoroutine());
        //StartCoroutine("SpawnCoroutine"); // << string 메서드 이름을 가져올 때 문제점 : 철자, 대소문자 틀리면, 어디에서 문제가 발생했는지 버그 찾기가 어렵다.

        // 두 방식 중에 어떤 코루틴 호출 방식을 사용하면 될까요?
        // 두 방식 중에 원하는 방식을 사용하되, 방식의 하나 방식으로 통일해주세요.
    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spawnPositions.Length);
            int randomMonsterIndex = UnityEngine.Random.Range(0, spawnMonsters.Length);

            Instantiate(spawnMonsters[randomMonsterIndex], spawnPositions[randomIndex]);

            // monsterInfos
            //monsterInfos[randomMonsterIndex].MonsterConstructor();
                     
            // interval 시간 후에 위에 코드를 다시 실행하라.
            yield return new WaitForSeconds(spawnIntervalTime);
        }
    }
}
