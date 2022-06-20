using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] float speed;�@�@�@//�{�[���̑��x
    [SerializeField] Vector2 direction;//�{�[���̐i�s����

    // Start is called before the first frame update
    void Start()
    {
        //�{�[���̐i�s�����̐��K��(�x�N�g���̒����̒P�ꉻ)
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[���̈ړ�����
        //direction��speed��time.deltaTime���|���A���̕����Ɉړ�����
        this.transform.Translate(direction* speed * Time.deltaTime);

        //Vector3 tempPos = transform.position;
        //tempPos += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0);
        //transform.position = tempPos;
    }


    //�����蔻��
    //�����蔻����g�p����ہA
    //��̃I�u�W�F�N�g�ǂ���ɂ�Collider�R���|�[�l���g���K�{�ɂȂ�܂��B
    //�����āA�Œ�ǂ��炩��Rigidbody�R���|�[�l���g���K�{

    //�����蔻��Ɋւ��֐�

    //�����ʂ̃I�u�W�F�N�g���ڐG�������A�Ăяo�����֐�
    //�����ɂ́A�ڐG�����I�u�W�F�N�g�̏�񂪓����Ă���B
    private void OnCollisionEnter(Collision collision)
    {
        //�^�O�ɂ���������
        //if(collision.gameObject.CompareTag("wall"))
        //{
        //    Debug.Log("�ڐG���܂���");
        //}

        //�{�[���̔��� (direction�̕����̕ύX)
        //collision.contacts...�ڐG�_�i�����j
        foreach (var point in collision.contacts)
        {
            //���g�̍��W�ƐڐG�_�̍������߂�i���x�N�g���������j 
            Vector3 diff = transform.position - (Vector3)point.point;

            //���x�N�g����X��Y�ǂ��炪�傫�����ŁA�ǂ���̎��𔽓]�����������
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

    //�����ʂ̃I�u�W�F�N�g���ڐG���Ă���ԁA�Ăяo�����֐�
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //�����ʂ̃I�u�W�F�N�g�Ƃ̐ڐG���I���������A�Ăяo�����֐�
    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
