using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteGameManager : MonoBehaviour
{
    //リザルト
    [SerializeField]
    Text result;
    //ルーレット結果
    [SerializeField]
    GameObject rouletteResult;
    //ルーレットにアタッチされているスクリプトを取得
    RouletteScript rouletteScript;
    //計算用
    float num;

    void Start()
    {
        rouletteScript = rouletteResult.GetComponent<RouletteScript>();
    }

    //なるべくupdateを使わないように気を配りましたが、時間の都合上と技量不足により使わざるを得ませんでした；；
    void Update()
    {
    #region 渡された値を元に結果を表示する
        //ルーレットから渡された値を取得
        num = rouletteScript.Rot;
        //値を360以内に抑える
        while(true)
        {
            if((Mathf.Abs(num) > 360))
            {
                num -= 360;
            }
            else
            {
                break;
            }
        }
        //ルーレット結果
           if (num > 0)
            {

                if(331 <= num || num <= 30)
                {
                result.text = "凶";
                }
                else if(31 <= num && num <= 90)
                {
                    result.text = "大吉";
                }
                else if (91 <= num && num <= 150)
                {
                    result.text = "大凶";
                }
                else if (151 <= num && num <= 210)
                {
                    result.text = "小吉";
                }
                else if (211 <= num && num <= 270)
                {
                    result.text = "末吉";
                }
                else if (271 <= num && num <= 330)
                {
                    result.text = "中吉";
                }

            }
            else
            {
                if (-331 >= num || num >= -30)
                {
                    result.text = "凶";
                }
                else if (-31 >= num && num >= -90)
                {
                    result.text = "中吉";
                }
                else if (-91 >= num && num >= -150)
                {
                    result.text = "末吉";
                }
                else if (-151 >= num && num >= -210)
                {
                    result.text = "小吉";
                }
                else if (-211 >= num && num >= -270)
                {
                    result.text = "大凶";
                }
                else if (-271 >= num && num >= -330)
                {
                    result.text = "大吉";
                }
            }
    #endregion
    }

}
