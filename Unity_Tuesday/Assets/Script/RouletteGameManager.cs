using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteGameManager : MonoBehaviour
{
    //���U���g
    [SerializeField]
    Text result;
    //���[���b�g����
    [SerializeField]
    GameObject rouletteResult;
    //���[���b�g�ɃA�^�b�`����Ă���X�N���v�g���擾
    RouletteScript rouletteScript;
    //�v�Z�p
    float num;

    void Start()
    {
        rouletteScript = rouletteResult.GetComponent<RouletteScript>();
    }

    //�Ȃ�ׂ�update���g��Ȃ��悤�ɋC��z��܂������A���Ԃ̓s����ƋZ�ʕs���ɂ��g�킴��𓾂܂���ł����G�G
    void Update()
    {
    #region �n���ꂽ�l�����Ɍ��ʂ�\������
        //���[���b�g����n���ꂽ�l���擾
        num = rouletteScript.Rot;
        //�l��360�ȓ��ɗ}����
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
        //���[���b�g����
           if (num > 0)
            {

                if(331 <= num || num <= 30)
                {
                result.text = "��";
                }
                else if(31 <= num && num <= 90)
                {
                    result.text = "��g";
                }
                else if (91 <= num && num <= 150)
                {
                    result.text = "�勥";
                }
                else if (151 <= num && num <= 210)
                {
                    result.text = "���g";
                }
                else if (211 <= num && num <= 270)
                {
                    result.text = "���g";
                }
                else if (271 <= num && num <= 330)
                {
                    result.text = "���g";
                }

            }
            else
            {
                if (-331 >= num || num >= -30)
                {
                    result.text = "��";
                }
                else if (-31 >= num && num >= -90)
                {
                    result.text = "���g";
                }
                else if (-91 >= num && num >= -150)
                {
                    result.text = "���g";
                }
                else if (-151 >= num && num >= -210)
                {
                    result.text = "���g";
                }
                else if (-211 >= num && num >= -270)
                {
                    result.text = "�勥";
                }
                else if (-271 >= num && num >= -330)
                {
                    result.text = "��g";
                }
            }
    #endregion
    }

}
