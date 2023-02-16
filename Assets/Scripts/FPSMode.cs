using UnityEngine;
using UnityEngine.Events;

public class FPSMode : MonoBehaviour
{
    [SerializeField] private float _modeTime = 30f;
    [SerializeField] private float _spawnTime = 2.5f;

    [SerializeField] private Spawner _spawner;

    [SerializeField] private GameObject _gameoverPanel;

    private int _score;
    private bool _isStarted = false;

    public UnityAction<int> ScoreChanged;
    public UnityAction<float> TimeChanged;

    public int Score => _score;
    public bool IsStarted => _isStarted;

    private void Start()
    {
        ShowCursor(true);
    }

    private void Update()
    {
        KeepCountdown();
    }

    public void ShowCursor(bool isActive)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = isActive;
    }

    public void ChangeScore(int score)
    {
        _score += score;

        if (_score < 0)
            _score = 0;

        ScoreChanged?.Invoke(_score);
        Debug.Log($"Очки:{_score}");
    }

    public void StartCountdown()
    {
        _isStarted = true;
        InvokeRepeating("Spawn", 0f, _spawnTime);
    }

    private void Spawn()
    {
        if (_isStarted)
            _spawner.Spawn();
    }

    private void KeepCountdown()
    {
        if (_isStarted)
            _modeTime -= Time.deltaTime;

        if (_modeTime <= 0)
        {
            GameOver();
            _modeTime = 0f;
        }

        TimeChanged?.Invoke(_modeTime);
    }

    private void GameOver()
    {
        _isStarted = false;
        _gameoverPanel.SetActive(true);
        ShowCursor(true);
    }
}