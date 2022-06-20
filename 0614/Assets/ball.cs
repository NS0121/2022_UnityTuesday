using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] float speed;　　　//ボールの速度
    [SerializeField] Vector2 direction;//ボールの進行方向

    // Start is called before the first frame update
    void Start()
    {
        //ボールの進行方向の正規化(ベクトルの長さの単一化)
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールの移動処理
        //directionにspeedとtime.deltaTimeを掛け、その方向に移動する
        this.transform.Translate(direction* speed * Time.deltaTime);

        //Vector3 tempPos = transform.position;
        //tempPos += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0);
        //transform.position = tempPos;
    }


    //当たり判定
    //当たり判定を使用する際、
    //二つのオブジェクトどちらにもColliderコンポーネントが必須になります。
    //加えて、最低どちらかにRigidbodyコンポーネントが必須

    //当たり判定に関わる関数

    //何か別のオブジェクトが接触した時、呼び出される関数
    //引数には、接触したオブジェクトの情報が入ってくる。
    private void OnCollisionEnter(Collision collision)
    {
        //タグによる条件分岐
        //if(collision.gameObject.CompareTag("wall"))
        //{
        //    Debug.Log("接触しました");
        //}

        //ボールの反射 (directionの方向の変更)
        //collision.contacts...接触点（複数）
        foreach (var point in collision.contacts)
        {
            //自身の座標と接触点の差を求める（差ベクトルを所得） 
            Vector3 diff = transform.position - (Vector3)point.point;

            //差ベクトルのXとYどちらが大きいかで、どちらの軸を反転させるを決定
            if(Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
            {
                direction.x *= -1;
            }
            else
            {
                direction.y *= -1;
            }
        }
    }

    //何か別のオブジェクトが接触している間、呼び出される関数
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //何か別のオブジェクトとの接触が終了した時、呼び出される関数
    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
