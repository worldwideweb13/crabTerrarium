using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム上のデータの書き換えクラス
/// </summary>
public class ScoreBase : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    public void SetCustomText<T>(ref T score, ref T text)
    {
        _text.text = score.ToString() + text.ToString();
    }

    public void SetText(string score)
    {
        _text.text = score;

    }
}
