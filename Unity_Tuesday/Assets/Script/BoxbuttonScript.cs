using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxbuttonScript : MonoBehaviour
{
    [SerializeField] private GameObject bigBButton;
    [SerializeField] private GameObject rotateBButton;
    Vector3 boxTransform;
    Vector3 boxRotate;
    Vector3 initializationTransform;
    Vector3 bigButton;
    Vector3 initializationRotate;
    Vector3 rotateButton;
    const float magnification = 1.5f;
    const float Fps = 12f;
    private int countBigA = 0;
    private int countBigB = 0;
    private int countRotateA = 0;
    private int countRotateB = 0;
    // Start is called before the first frame update
    void Start()
    {
        //中央の箱の大きさと回転
        boxTransform = this.transform.localScale;
        boxRotate = this.transform.localEulerAngles;
        //元の大きさに戻す際に使用
        initializationTransform = this.transform.localScale;
        initializationRotate = rotateBButton.transform.localEulerAngles;
        //取得した各ボタンの大きさや回転
        bigButton = bigBButton.transform.localScale;
        rotateButton = rotateBButton.transform.localEulerAngles;
    }
    #region 大きさを1.5倍にしたり戻したり。
    public void BigA()
    {
        if(countBigA % 2 == 0)
        {
            boxTransform *= magnification;
            this.transform.localScale = boxTransform;
        }
        else
        {
            boxTransform /= magnification;
            this.transform.localScale = boxTransform;
        }
        countBigA++;
    }
    #endregion

    #region ボタンの大きさを元に1.5倍にし、戻す際は元の大きさに戻す。
    public void BigB()
    {
        if (countBigB % 2 == 0)
        {
            bigButton *= magnification;
            this.transform.localScale = bigButton;
        }
        else
        {
            bigButton /= magnification;
            this.transform.localScale = initializationTransform;
        }
        countBigB++;
    }
    #endregion

    #region 1秒間に1回転する
    public void RotateA()
    {
        countRotateA++;
        do
        {
            StartCoroutine(BoxRotateACoroutine());
        } while (false);
    }
    IEnumerator BoxRotateACoroutine()
    {
        while (countRotateA % 2 == 1)
        {
            boxRotate.z ++;
            this.transform.localEulerAngles = boxRotate;
            yield return new WaitForSeconds(0.003f);
        }
    }
    #endregion

    #region 毎回ボタンの回転を元に1秒間に2回転する
    public void RotateB()
    {
        countRotateB++;
        if (countRotateB % 2 == 1)
        {
            rotateButton = initializationRotate;
            Debug.Log("");
        }
        do
        {
            StartCoroutine(BoxRotateBCoroutine());
        } while (false);
    }

    IEnumerator BoxRotateBCoroutine()
    {
        while (countRotateB % 2 == 1)
        {
            rotateButton.z ++;
            this.transform.localEulerAngles = rotateButton;
            yield return new WaitForSeconds(0.0015f);
        }
    }
    #endregion

}
