using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public StatType type = StatType.UnDefined;
    public float Value = 5.0f;
}

public class ObjectBuff : MonoBehaviour
{
    Entity_stats statsToMod;
    SpriteRenderer sr;
    // Tag가 Player인 객체와 충돌했을 때   => OnT, OnC

    [Header("Buff Detail")]
    [SerializeField] Buff[] buffs;
    [SerializeField] private float buffTime = 5.0f;
    [SerializeField] private string buffName;
  

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // collision으로 부터 Component를 Get해서 statsToMod저장하세요.\

            statsToMod = collision.GetComponent<Entity_stats>();
            StartCoroutine(BuffCo());         
        }
    }

    IEnumerator BuffCo()
    {

        sr.color = Color.clear;
       
        foreach(Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).AddModifier(buff.Value, buffName);
        }
    
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());

        yield return new WaitForSeconds(buffTime);
        //  ??초 Delay후에 증가되었던 임시 스탯을 없애고, 이 오브젝트를 파괴하라

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).RemoveModifier(buffName); // Item경로로 부터 얻은 스탯을 제거하라.
        }
       
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());
        Destroy(gameObject);
    }

}
