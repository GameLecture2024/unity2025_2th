using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEventUI : MonoBehaviour
{
    [Header("NPC UI")]
    public GameObject NPCPanel;
    public Image NpcSprite;
    public TextMeshProUGUI NpcName;
    public TextMeshProUGUI NpcDialogue;

    [Header("GameOver UI")]
    public GameObject GameOverPanel;

    [Header("GameClear UI")]
    public GameObject GameClearPanel;

    private void Start()
    {
        // 유니티 씬에서 실수로 활성화 해둔 상태여도, 코드로 비활성화 해준다.
        NPCPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        //GameClearPanel.SetActive(false);
    }

    private void OnEnable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent += HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent += HandleGameOver;
    }

    private void OnDisable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent -= HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent -= HandleGameOver;
    }

    private void HandleGameOver(IGameOverEvent evt)  // 여러분을 처치한 대상에 따라서 GameOver 내용이 바뀌는 UI 존재한다.
    {
        Time.timeScale = 0f; // Time.scale 원상태로 돌려줘야한다.
        GameOverPanel.SetActive(true);

    }

    private void HandleNPCUI(ICollisionWithPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NpcSprite.sprite = evt.npc.npcInfo.Sprite;
        NpcName.SetText(evt.npc.npcInfo.NpcName);
        NpcDialogue.SetText(evt.npc.npcInfo.NPCDialogue);
    }
}
