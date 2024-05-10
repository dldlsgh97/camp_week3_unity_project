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

    public void OnClickJoinBtn()
    {
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
}
