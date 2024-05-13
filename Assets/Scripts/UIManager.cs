using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startUI;
    [SerializeField] InputField nameInput;
    [SerializeField] Text nameText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerChoiceWindow;
    [SerializeField] GameObject player_Penguin;
    [SerializeField] GameObject player_Knight;

    [SerializeField] Text timeText;
    DateTime currentTime;

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
    public void OnClickJoinBtn()
    {
        Debug.Log("Click JoinBtn");
        if(nameInput != null)
        {
            int nameLength = nameInput.text.Length;
            if(nameLength > 1)
            {
                player.SetActive(true);
                nameText.text = $"{nameInput.text}";
                startUI.SetActive(false);
            }
        }
    }
    private void Update()
    {
        currentTime = DateTime.Now;
        int hour = currentTime.Hour;
        int minute = currentTime.Minute;
        timeText.text = $"{hour}:{minute}";
    }
    public void OpenCharacterChoiceWindow()
    {
        Debug.Log("UIManager Func");
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
}
