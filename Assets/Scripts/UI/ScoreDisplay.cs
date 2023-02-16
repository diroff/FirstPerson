using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private FPSMode _fpsMode;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _fpsMode.ScoreChanged += ChangeScore;
    }

    private void OnDisable()
    {
        _fpsMode.ScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int currentScore)
    {
        _scoreText.text = "Score:" + currentScore;
    }
}
