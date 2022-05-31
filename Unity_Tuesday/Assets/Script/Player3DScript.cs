using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DScript : MonoBehaviour
{
    float Speed = 0; //速度(x座標)
    float Speeds = 0; //速度（z座標）
    Vector3 startPos;

    void Update()
    {
        //スワイプの長さを求める
        if (Input.GetMouseButtonDown(0))
        {
            //マウスをクリックした座標
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //マウスを離した座標
            Vector3 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            //スワイプの長さを初速度に変換する
            this.Speed = swipeLength / 500.0f;
            this.Speeds = swipeLength / 500.0f;

        }
        //縦横斜め移動させる
        transform.Translate(this.Speed, 0, this.Speeds);
        //速度を減速させる
        this.Speed *= 0.98f;
        this.Speeds *= 0.98f;        
    }
}
