using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _endText;
    [SerializeField] private FPSMode _fpsMode;

    private void Start()
    {
        _endText.text = "Игра окончена!\nОчки:" + _fpsMode.Score;
    }

}
