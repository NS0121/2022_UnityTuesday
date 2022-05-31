using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwaipScript : MonoBehaviour
{
    private Vector3 playerPos;
    private Vector3 mousePos;
    public GameObject Daishi;
    private Vector3 DaishiPos;

    // �v���C���[�̑��x�������t�B�[���h��ǉ�
    private Vector3 velocity;

    // ���x�̌������������t�B�[���h��ǉ�
    // 0�Ȃ�s�^�b�Ǝ~�܂�A1�Ȃ猸��������ё�����
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

            // �ړ��O��̈ʒu�̍����瑬�x�����߂�velocity�ɕۑ����Ă���
            velocity = (this.transform.position - prePos) / Time.deltaTime;
        }
        else
        {
            // �X���C�v���łȂ��Ƃ��Avelocity�����������Ȃ���v���C���[���ړ�����
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
