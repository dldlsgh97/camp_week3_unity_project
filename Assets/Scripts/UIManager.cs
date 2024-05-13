using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header ("Start UI")]
    [SerializeField] GameObject startUI;
    [SerializeField] InputField nameInput;
    [SerializeField] Text nameText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerChoiceWindow;
    [SerializeField] GameObject player_Penguin;
    [SerializeField] GameObject player_Knight;
    

    [Header("Time UI")]
    [SerializeField] Text timeText;
    DateTime currentTime;

    [Header("Ingame UI")]
    [SerializeField] GameObject inGameUI;

    [Header("Ingame UI_Name")]
    [SerializeField] GameObject changeNameUI;
    [SerializeField] InputField changeNameInput;
    [SerializeField] GameObject nameListUI;
    [SerializeField] Text sideBarPlayernametxt;
    [SerializeField] Text sideBarNPCNametxt;
    [SerializeField] Text npcNameText;

    [Header("Npc Chat")]
    [SerializeField] GameObject npcObject;
    private float _distance;
    [SerializeField] GameObject chatStartUI;
    [SerializeField] GameObject chatUI;
    bool isChatClose = true;

    private void Start()
    {
        if (GameManager.Instance.playerId == -1)
        {
            player_Penguin.SetActive(true);
        }
        else
        {
            player_Knight.SetActive(true);
        }
        
    }
    
    private void Update()
    {
        currentTime = DateTime.Now;
        int hour = currentTime.Hour;
        int minute = currentTime.Minute;
        timeText.text = $"{hour}:{minute}";

        _distance = Vector2.Distance(player.transform.position, npcObject.transform.position);
        if(_distance <= 4.5f && isChatClose)
        {
            ShowChatStartUI();
        }
        else if (_distance >= 4.5f)
        {
            CloseChatStartUI();
        }

    }
    public void OnClickJoinBtn()
    {
        if (nameInput != null)
        {
            int nameLength = nameInput.text.Length;
            if (nameLength > 1)
            {
                player.SetActive(true);
                nameText.text = $"{nameInput.text}";
                startUI.SetActive(false);
            }
        }
        inGameUI.SetActive(true);
        NameListUpdate();
    }
    public void OpenCharacterChoiceWindow()
    {
        if (GameManager.Instance.playerId == -1)
        {
            player_Penguin.SetActive(false);
        }
        else
        {
            player_Knight.SetActive(false);
        }
        playerChoiceWindow.SetActive(true);

    }
    public void ChoosePenguin()
    {
        GameManager.Instance.playerId = -1;
        CloseCharacterChoiceWindow();
    }
    public void ChooseKnight()
    {
        GameManager.Instance.playerId = 1;
        CloseCharacterChoiceWindow();
    }

    public void CloseCharacterChoiceWindow()
    {
        playerChoiceWindow.SetActive(false);
        if (GameManager.Instance.playerId == -1)
        {
            player_Penguin.SetActive(true);           
        }
        else
        {
            player_Knight.SetActive(true);
        }
    }

    public void OpenChangePlayerName()
    {
        changeNameUI.SetActive(true);
        
    }
    public void ChangeName()
    {
        if (changeNameInput != null)
        {
            int changeNameInputLenghth = nameInput.text.Length;
            if (changeNameInputLenghth > 1)
            {
                nameText.text = $"{changeNameInput.text}";
                changeNameUI.SetActive(false);
            }
        }
        NameListUpdate();
    }

    public void OnClickNameListBtn()
    {
        nameListUI.SetActive(true);
    }
    public void CloseNameListBtn()
    {
        nameListUI.SetActive(false);
    }

    void NameListUpdate()
    {
        sideBarNPCNametxt.text = $"{npcNameText.text}";
        sideBarPlayernametxt.text = $"{nameText.text}";
    }

    public void IngameChangePlayer()
    {
        playerChoiceWindow.SetActive(true);
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
