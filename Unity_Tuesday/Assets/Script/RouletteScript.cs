using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteScript : MonoBehaviour
{
    //回転スピード
    float rotSpeed = 0;
    //マウス座標
    Vector2 startPos;
    //減速率
    [SerializeField, HeaderAttribute("減速率")]
    private float decelerateSpeed = 0.99f;
    //マネージャへ渡す値
    [HideInInspector]
    public float Rot;

    void Start()
    {
        StartCoroutine("Roulette");
    }
    #region ルーレットを回転させるコルーチン
    IEnumerator Roulette()
    {
        while(true)
        {
            //マウス入力
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - this.startPos.x;

                this.rotSpeed = swipeLength;
            }
            //回転
            transform.Rotate(0, 0, this.rotSpeed);

            //減速
            this.rotSpeed *= decelerateSpeed;

            //マネージャーに渡すための値を生成
            Rot = this.transform.localEulerAngles.z;
            yield return null;
        }
    }
    #endregion
}
