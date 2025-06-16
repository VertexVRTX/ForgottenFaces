using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    public RectTransform hourHand;
    public RectTransform minuteHand;
    public float targetHourAngle;
    public float targetMinuteAngle;
    public float tolerance = 5f;

    public GameObject clockPanel;
    public GameObject openClockPanel;

    private bool puzzleSolved = false;

    void Update()
    {
        if (puzzleSolved) return;

        float currentHourAngle = NormalizeAngle(hourHand.localEulerAngles.z);
        float currentMinuteAngle = NormalizeAngle(minuteHand.localEulerAngles.z);

        if (Mathf.Abs(currentHourAngle - targetHourAngle) < tolerance &&
            Mathf.Abs(currentMinuteAngle - targetMinuteAngle) < tolerance)
        {
            puzzleSolved = true;
            OnPuzzleSolved();
        }
    }

    float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle < 0) angle += 360;
        return angle;
    }

    void OnPuzzleSolved()
    {
        hourHand.gameObject.SetActive(false);
        minuteHand.gameObject.SetActive(false);
        
        clockPanel.SetActive(false);
        
        openClockPanel.SetActive(true);
    }
}
