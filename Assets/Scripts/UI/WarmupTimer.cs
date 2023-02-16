using TMPro;
using UnityEngine;

public class WarmupTimer : MonoBehaviour
{
    [SerializeField] private float _timeBeforeStart = 3f;
    
    [SerializeField] private FPSMode _fpsMode;

    [SerializeField] private TextMeshProUGUI _timerText;

    private void Update()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        _timeBeforeStart -= Time.deltaTime;

        if (_timeBeforeStart <= 0)
        {
            _timeBeforeStart = 0;
            _fpsMode.StartCountdown();
            gameObject.SetActive(false);
        }

        _timerText.text = "" + (int)(_timeBeforeStart + 1);
    }
}
