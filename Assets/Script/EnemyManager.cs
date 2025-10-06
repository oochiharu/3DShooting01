using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̐����Ǘ�������
/// </summary>
public class EnemyManager : MonoBehaviour
{
    /// <summary>
    /// �R�s�[���̓GObject
    /// </summary>
    [SerializeField] private EnemyBase _originalEnemy;

    /// <summary>
    /// �쐬������܂ł̎���
    /// </summary>
    private float _createTimer = 0;




    /// <summary>
    /// �ŏ��ɌĂ΂��
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// ����Ă΂��
    /// </summary>
    void Update()
    {
        //5�b�o�߂��ĂȂ��Ȃ��ɐi�܂Ȃ�
        if (_createTimer < 5.0f)
		{
            _createTimer += Time.deltaTime;
            return;
		}
        _createTimer = 0;

        //�G�̕��������
        EnemyBase enemyBase = (EnemyBase)Instantiate(_originalEnemy,
            new Vector3(UnityEngine.Random.Range(-80.0f, 80.0f),
            UnityEngine.Random.Range(-60.0f, 80.0f),
            UnityEngine.Random.Range(20.0f, 180.0f)),
            Quaternion.identity
            );
        //���������������
        enemyBase.gameObject.transform.LookAt(Camera.main.transform.localPosition);
    }
}
