using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�ۂ̏���
/// </summary>
public class ShotMove : MonoBehaviour
{
    /// <summary>
    /// �ˌ��̐�������
    /// </summary>
    private float _shotLifeTimer = 2.0f;
    
    //�@����ŌĂ΂��
    void Start()
    {
        
    }

    //����Ă΂��
    void Update()
    {
        //�b�������炷
        _shotLifeTimer -= Time.deltaTime;
        //�������Ԃ��Ȃ��Ȃ�
        if (_shotLifeTimer <= 0)
		{
            //Object���폜�����
            Destroy(gameObject);
		}
    }

    /// <summary>
    /// �����ɂԂ�������Ăяo����鏈��
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Object���폜�����
            Destroy(gameObject);
        }

    }
}
