using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ˌ��̐��������
/// </summary>
public class ShotControl : MonoBehaviour
{
    /// <summary>
    /// �R�s�[���̒e��Object
    /// </summary>
    [SerializeField] private GameObject _shotOriginal;

    /// <summary>
    /// �ˌ��Ԋu�̂��߂̃^�C�}�[
    /// </summary>
    private float _timer = 0;

    /// <summary>
    /// ��ɌĂ΂��
    /// </summary>
    void Update()
    {
        _timer += Time.deltaTime;
        //0.25�b�Ɉ�񓮍삳����
        if (_timer <= 0.25f)
		{
            return;
		}
        _timer = 0;

        //���C�̍쐬
        Ray ray = new Ray(Camera.main.transform.localPosition, Camera.main.transform.forward);
        RaycastHit hit;
        //�ő勗��
        const float maxDistance = 600;
        //���C�Ƀq�b�g�����I�u�W�F�N�g���������ꍇ
        if(Physics.Raycast(ray,out hit,maxDistance))
		{
            //���C�Ƀq�b�g�����I�u�W�F�N�g
            GameObject hitObject = hit.collider.gameObject;
            //���݂��Ȃ��Ȃ珈�����Ȃ�
            if(hitObject == null)
			{
                return;
			}
            //�G�ȊO�������珈�����Ȃ�
            if(hitObject.tag != "Enemy")
			{
                return;
			}
            //�ˌ��̔����ꏊ
            Vector3 position = Camera.main.transform.localPosition;
            //�ˌ��̃N���[�����쐬
            GameObject shotClone = (GameObject)Instantiate(_shotOriginal, position, Quaternion.identity);
            //AddForce�őł��o��
            Rigidbody shotRigidBody = shotClone.gameObject.GetComponent<Rigidbody>();
            //�J�����̌����̕����փp���[��������
            shotRigidBody.AddForce(Camera.main.transform.forward * 10000);

            //�v���C���[�U�����[�V����
            PlayerBase.GetInstance().PlayerAttack();
        }

    }
}
