using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DaySinceFirstLaunch : MonoBehaviour
{
    DateTime startDate;
    DateTime today;

    private void Start()
    {
        SetStartDate();  
    }

    private void SetStartDate()
    {
        if (PlayerPrefs.HasKey("StartDate"))
        {
            startDate = Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
        }
        else
        {
            startDate = DateTime.Now;
            PlayerPrefs.SetString("StartDate", startDate.ToString());
        }
        PlayerPrefs.SetInt("DaysPlayed", GetDaysPlayed());
    }

    private int GetDaysPlayed()
    {
        today = DateTime.Now;

        return int.Parse(today.Subtract(startDate).TotalDays.ToString("0"));
    }
}
