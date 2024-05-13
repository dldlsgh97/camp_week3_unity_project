using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUIManager : MonoBehaviour
{
    [Header("Npc Chat")]
    [SerializeField] GameObject npcObject;
    private float _distance;
    [SerializeField] GameObject chatStartUI;
    [SerializeField] GameObject chatUI;
    bool isChatClose = true;

    void Update()
    {
        #region 플레이어와 NPC거리 계산후 ChatStartUI띄워주기
        _distance = Vector2.Distance(UIManager.Instance.player.transform.position, npcObject.transform.position);
        if (_distance <= 4.5f && isChatClose)
        {
            ShowChatStartUI();
        }
        else if (_distance >= 4.5f)
        {
            CloseChatStartUI();
        }
        #endregion
    }

    void ShowChatStartUI()
    {
        chatStartUI.SetActive(true);
    }
    void CloseChatStartUI()
    {
        chatStartUI.SetActive(false);
    }
    public void ClickChatStartEnterBtn()
    {
        chatStartUI.SetActive(false);
        isChatClose = false;
        ShowChatUI();
    }

    void ShowChatUI()
    {
        chatUI.SetActive(true);
    }
    void CloseChatUI()
    {
        chatUI.SetActive(false);
    }
    public void ClickChatEnterBtn()
    {
        CloseChatUI();
        isChatClose = true;
    }
}
