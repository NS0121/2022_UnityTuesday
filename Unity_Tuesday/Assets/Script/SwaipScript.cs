using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwaipScript : MonoBehaviour
{
    private Vector3 playerPos;
    private Vector3 mousePos;
    public GameObject Daishi;
    private Vector3 DaishiPos;

    // プレイヤーの速度を示すフィールドを追加
    private Vector3 velocity;

    // 速度の減衰率を示すフィールドを追加
    // 0ならピタッと止まり、1なら減速せず飛び続ける
    [Range(0.0f, 1.0f)] public float Attenuation = 0.5f;

    void Update()
    {
        playerControl();
        DaishiPos = Daishi.transform.position;
        DaishiPos.x = Mathf.Clamp(DaishiPos.x, 0f, 0f);
        DaishiPos.y = Mathf.Clamp(DaishiPos.y, -21f, 21f);
        transform.position = new Vector3(DaishiPos.x, DaishiPos.y);
    }

    private void playerControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerPos = this.transform.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 prePos = this.transform.position;
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

            diff.z = 0.0f;
            this.transform.position = playerPos + diff;

            // 移動前後の位置の差から速度を求めてvelocityに保存しておく
            velocity = (this.transform.position - prePos) / Time.deltaTime;
        }
        else
        {
            // スワイプ中でないとき、velocityを減衰させながらプレイヤーを移動する
            velocity *= Mathf.Pow(Attenuation, 10.0f * Time.deltaTime);
            this.transform.position += velocity * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerPos = Vector3.zero;
            mousePos = Vector3.zero;
        }
    }
}
