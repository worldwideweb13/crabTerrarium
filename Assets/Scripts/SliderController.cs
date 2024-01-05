using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// 体力、水槽のゲージの挙動管理
/// </summary>
public class SliderController : MonoBehaviour
{
    public Image sliderImage;
    public TextMeshProUGUI valueText;

    public void UpdateUI(int score)
    {
        valueText.text = score.ToString() + "%";
        sliderImage.fillAmount = (float)Math.Clamp(score / 100.0 , 0f, 1f);
    }

}
