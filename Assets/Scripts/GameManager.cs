using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //������ ���� �÷��̾� ĳ���� ������ GameManager�� ����
    public int playerId = -1;
   
    private void Awake()
    {
        Instance = this;
    }
}
