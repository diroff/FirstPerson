using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private FPSMode _fpsMode;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void OnEnable()
    {
        _fpsMode.TimeChanged += ChangeTime;
    }

    private void OnDisable()
    {
        _fpsMode.TimeChanged -= ChangeTime;
    }

    private void ChangeTime(float timeLeft)
    {
        _timerText.text = "Time:" + (int)timeLeft;
    }
}
