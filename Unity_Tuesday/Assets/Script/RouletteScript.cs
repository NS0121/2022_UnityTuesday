using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteScript : MonoBehaviour
{
    float rotSpeed = 0;
    Vector2 startPos;
    [SerializeField, HeaderAttribute("減速")]
    private float decelerateSpeed = 0.9f;
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
            transform.Rotate(0, 0, this.rotSpeed);

            this.rotSpeed *= decelerateSpeed;

            Rot = this.transform.localEulerAngles.z;
            yield return null;
        }
    }
    #endregion
}
