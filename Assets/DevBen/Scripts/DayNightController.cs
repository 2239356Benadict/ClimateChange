// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to control the light for day and night effect.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DayNightController : MonoBehaviour
{
    public Light directionalLight;

    public float timerSpeed;
    public float startHour;
    public float sunRiseHour;
    public float sunSetHour;
    public TextMeshProUGUI timeText;
    private TimeSpan sunRiseTime;
    private TimeSpan sunSetTime;
    private DateTime dateTime;

    public Color dayAmbientLightColor;
    public Color nightAmbientLightColor;

    void Start()
    {
        dateTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunRiseTime = TimeSpan.FromHours(sunRiseHour);
        sunSetTime = TimeSpan.FromHours(sunSetHour);
    }



    void Update()
    {
        UpdateDayAndNight();
        RotateSun();
    }



    private void UpdateDayAndNight()
    {
        dateTime = dateTime.AddSeconds(Time.deltaTime * timerSpeed);

        if (timeText != null)
        {
            timeText.text = dateTime.ToString("HH:mm");
        }
    }

    /// <summary>
    /// Method to rotate the light according to the time.
    /// </summary>
    private void RotateSun()
    {
        float sunLightRotation;

        if(dateTime.TimeOfDay > sunRiseTime && dateTime.TimeOfDay < sunSetTime)
        {
            TimeSpan sunRiseToSunSetDuration = CalculateTheTimeDifference(sunRiseTime, sunSetTime);
            TimeSpan timeSinceSunRIse = CalculateTheTimeDifference(sunRiseTime, dateTime.TimeOfDay);
            double percentage = timeSinceSunRIse.TotalMinutes / sunRiseToSunSetDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunSetToSunRiseDuration = CalculateTheTimeDifference(sunSetTime, sunRiseTime);
            TimeSpan timeSinceSunSet = CalculateTheTimeDifference(sunRiseTime, dateTime.TimeOfDay);
            double percentge = timeSinceSunSet.TotalMinutes / sunSetToSunRiseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(180, 360, (float)percentge);
        }

        directionalLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private TimeSpan CalculateTheTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan timeDifference = toTime - fromTime;
        if (timeDifference.TotalSeconds < 0)
        {
            timeDifference += TimeSpan.FromHours(24);
        }
        return timeDifference;
    }
}
