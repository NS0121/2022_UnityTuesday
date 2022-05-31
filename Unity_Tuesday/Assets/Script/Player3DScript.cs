using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DScript : MonoBehaviour
{
    float Speed = 0; //���x(x���W)
    float Speeds = 0; //���x�iz���W�j
    Vector3 startPos;

    void Update()
    {
        //�X���C�v�̒��������߂�
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X���N���b�N�������W
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //�}�E�X�𗣂������W
            Vector3 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            //�X���C�v�̒����������x�ɕϊ�����
            this.Speed = swipeLength / 500.0f;
            this.Speeds = swipeLength / 500.0f;

        }
        //�c���΂߈ړ�������
        transform.Translate(this.Speed, 0, this.Speeds);
        //���x������������
        this.Speed *= 0.98f;
        this.Speeds *= 0.98f;        
    }
}
