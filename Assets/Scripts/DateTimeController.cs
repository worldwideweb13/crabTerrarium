// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// public class DateTimeController : MonoBehaviour
// {
//     /// <summary>
//     /// 体力ゲージ消費の間隔タイマー
//     /// </summary>
//     private float lifePointCounter = 10f;
//     private float aquariumPointCounter = 20f;
//     private float elapsedTime = 0f;
    

//     // Update is called once per frame
//     void Update()
//     {
//         elapsedTime += Time.deltaTime;
//         if(elapsedTime >= lifePointCounter)
//         {
//             // ヤドカリの体力を減らす
//             PlayerBase.GetInstance().lifePoint -= 5;
//         }

//         if(elapsedTime >= aquariumPointCounter)
//         {
//             // 水槽の清潔ポイントを減らす
//             PlayerBase.GetInstance().aquariumPoint -= 3;             
//         }

//     }

//     /// <summary>
//     /// 時間のセーブ
//     /// </summary>
//     private void SaveDateTime()
//     {
        
//     }

// }
