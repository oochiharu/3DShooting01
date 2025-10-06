using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e�ۋ���
/// </summary>
public class EnemyShotBase : MonoBehaviour
{
	/// <summary>
	/// �ˌ�����������
	/// </summary>
	public Action<EnemyShotBase> OnDead;

	/// <summary>
	/// �Ԃ�������
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		//�G�ȊO�ɂԂ�������
		if (other.tag != "Enemy")
		{
			if (other.tag == "MainCamera")
			{
				//�_���[�W���󂯂�
				PlayerBase.GetInstance().PlayerDamage();
			}
			//���g���폜����
			Destroy(gameObject);
		}
	}
}
