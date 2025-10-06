using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�����Ǘ�
/// �X�e�[�^�X�Ǘ�
/// </summary>
public class PlayerBase : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̗̑�
    /// </summary>
    public int LifePoint = 0;


    /// <summary>
    /// �_��
    /// </summary>
    private int _scorePoint = 0;

    /// <summary>
    /// ���g�̃N���X���i�[
    /// </summary>
    private static PlayerBase _instance;

    /// <summary>
    /// �̗͂̏��������N���X
    /// </summary>
    [SerializeField] private LifeBase _lifeBase;
    /// <summary>
    /// �_���̏��������N���X
    /// </summary>
    [SerializeField] private ScoreBase _scoreBase;
    /// <summary>
    /// �v���C���[�L�����̃A�j��
    /// </summary>
    [SerializeField] private Animator _playerAnimation;
    /// <summary>
    /// �Q�[���I�[�o�[�̓���
    /// </summary>
    [SerializeField] private GameOverBase _gameOverBase;



    /// <summary>
    /// �_���[�W���󂯂��A�j���[�V��������
    /// </summary>
    private float _damageTimer = 1.0f;

    //�U���A�j���[�V��������
    private float _attackTimer = 1.0f;

    /// <summary>
    /// �ŏ��ɌĂ΂��
    /// </summary>
    void Start()
    {
        //�����̗�
        LifePoint = 5;
        _scorePoint = 0;
        //��������
        _lifeBase.SetLife(LifePoint);
        //���g�̃N���X������
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //�_���[�W�A�j���[�V������
        if(_playerAnimation.GetBool("Damage"))
        {
            _damageTimer -= Time.deltaTime;
            if(_damageTimer <= 0)
            {
                //���Ԃ�0�ɂȂ�����_���[�W�A�j���[�V�����t���O���I�t�ɂ���
                _playerAnimation.SetBool("Damage", false);
            }
        }
        //�U���A�j���[�V������
        if (_playerAnimation.GetBool("Attack"))
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0)
            {
                //���Ԃ�0�ɂȂ�����U���A�j���[�V�����t���O���I�t�ɂ���
                _playerAnimation.SetBool("Attack", false);
            }
        }
    }

    /// <summary>
    /// PlayerBase�N���X���󂯎��
    /// </summary>
    /// <returns></returns>
    public static PlayerBase GetInstance()
	{
        return _instance;
	}

    /// <summary>
    /// �v���C���[���_���[�W���󂯂�
    /// </summary>
    public void PlayerDamage()
	{
        //�̗͂��O�Ȃ�_���[�W�����������Ȃ�
        if(LifePoint == 0)
        {  return; }

        LifePoint--;
        if (LifePoint == 0)
		{
            //���S����
            _gameOverBase.GameOverStart();
        }
        //�_���[�W�A�j���[�V����
        _playerAnimation.SetBool("Damage",true);
        //�A�j���[�V��������
        _damageTimer = 1.0f;

        _lifeBase.SetLife(LifePoint);
    }

    public void AddScore(int score)
    {
        _scorePoint += score;
        _scoreBase.SetScore(_scorePoint);
    }
    public void PlayerAttack()
    {
        //�U���A�j����������
        _playerAnimation.SetBool("Attack", true);
        _attackTimer = 1.0f;
    }
}
