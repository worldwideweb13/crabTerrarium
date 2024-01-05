using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.MUIP;
using UnityEngine;
//using System;

/// <summary>
/// ヤドカリ、水槽などの基本ステータスの管理クラス
/// </summary>
public class PlayerBase : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの各種スコア
    /// </summary>    
    private string crabName;
    public int lifePoint;
    public int aquariumPoint;
    private int playerGold;
    private int playTime;
    private DateTime DateAtFeeding;
    private DateTime DateAtCleaning;

    /// <summary>
    /// 各種スコアを減らす間隔タイマー
    /// </summary>
    private float lifePointCounter = 4f;
    private float aquariumPointCounter = 8f;
    /// <summary>
    /// 経過時間記録用プロパティ
    /// </summary>
    public float lifePointElapsedTime = 0f;
    public float aquariumPointElapsedTime = 0f;


    private static PlayerBase _instance;

    [SerializeField] private ScoreBase _nameBase;
    [SerializeField] private ScoreBase _goldBase;
    [SerializeField] private ScoreBase _dateBase;
    [SerializeField] private SliderController _lifeBase;
    [SerializeField] private SliderController _cleanBase;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("ResetFlg"))
        {
            crabName = "アを書き換える";
            lifePoint = 100;
            aquariumPoint = 100;
            playerGold = 123456;
            playTime = 1;

            _nameBase.SetText(crabName);
            _goldBase.SetText(playerGold.ToString() + "G");
            _dateBase.SetText(playTime + "日目");
            _lifeBase.UpdateUI(lifePoint);
            _cleanBase.UpdateUI(aquariumPoint);
        } else {

        }
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        lifePointElapsedTime += Time.deltaTime;
        aquariumPointElapsedTime += Time.deltaTime;
        if(lifePointElapsedTime >= lifePointCounter)
        {
            // ヤドカリの体力を減らす
            lifePoint -= 3;
            _lifeBase.UpdateUI(lifePoint);
            lifePointElapsedTime = 0f;
            // TODO: ヤドカリの体力がゼロになった時の処理
        }

        if(aquariumPointElapsedTime >= aquariumPointCounter && aquariumPoint > 0)
        {
            // 水槽の清潔ポイントを減らす
            aquariumPoint -= 7;
            _cleanBase.UpdateUI(aquariumPoint);
            aquariumPointElapsedTime = 0f;
        }     
    }

    public static PlayerBase GetInstance()
    {
        return _instance;
    }
    
}
