using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [Header("Time UI")]
    [SerializeField] Text timeText;
    DateTime currentTime;

    private void Update()
    {
        #region 시간UI
        currentTime = DateTime.Now;
        int hour = currentTime.Hour;
        int minute = currentTime.Minute;
        timeText.text = $"{hour}:{minute}";
        #endregion       
    }
}