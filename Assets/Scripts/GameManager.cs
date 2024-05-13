using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //나중을 위해 플레이어 캐릭터 종류를 GameManager에 선언
    public int playerId = -1;
   
    private void Awake()
    {
        Instance = this;
    }
}
