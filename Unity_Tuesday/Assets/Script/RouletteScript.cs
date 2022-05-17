using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteScript : MonoBehaviour
{
    //��]�X�s�[�h
    float rotSpeed = 0;
    //�}�E�X���W
    Vector2 startPos;
    //������
    [SerializeField, HeaderAttribute("������")]
    private float decelerateSpeed = 0.99f;
    //�}�l�[�W���֓n���l
    [HideInInspector]
    public float Rot;

    void Start()
    {
        StartCoroutine("Roulette");
    }
    #region ���[���b�g����]������R���[�`��
    IEnumerator Roulette()
    {
        while(true)
        {
            //�}�E�X����
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
            //��]
            transform.Rotate(0, 0, this.rotSpeed);

            //����
            this.rotSpeed *= decelerateSpeed;

            //�}�l�[�W���[�ɓn�����߂̒l�𐶐�
            Rot = this.transform.localEulerAngles.z;
            yield return null;
        }
    }
    #endregion
}
