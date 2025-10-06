using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̋����𐧌�
/// </summary>
public class EnemyBase : MonoBehaviour
{
    /// <summary>
    /// �G�̗̑�
    /// </summary>
    public int LifePoint = 3;

    /// <summary>
    /// �ˌ��Ԋu�̂��߂̃^�C�}�[
    /// </summary>
    private float _timer = 0;

    [SerializeField] private GameObject _shotOriginal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// ���񏈗�������
    /// </summary>
    void Update()
    {
        _timer += Time.deltaTime;
        //9�b�Ɉ�񓮍삳����
        if (_timer <= 9.0f)
        {
            return;
        }
        _timer = 0;
        //�ˌ����s��

        //�ˌ��̃N���[�����쐬
        GameObject shotClone = (GameObject)Instantiate(_shotOriginal, transform.localPosition, Quaternion.identity);
        //�J�����̂ق�����������
        shotClone.transform.LookAt(Camera.main.transform.localPosition);
        //AddForce�őł��o��
        Rigidbody shotRigidBody = shotClone.gameObject.GetComponent<Rigidbody>();
        //�J�����̌����̕����փp���[��������
        shotRigidBody.AddForce(shotClone.transform.forward * 1000);
    }

    /// <summary>
    /// �����ɂԂ������瓮��
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
        //�G�ȊO�ɓ���������
		if (other.tag != "Enemy")
		{
            //�̗͂�1����
            LifePoint--;
            if(LifePoint == 0)
			{
                PlayerBase.GetInstance().AddScore(10);
                //�̗�0�Ȃ̂ŏ���
                Destroy(gameObject);
			}
        }
	}

}
