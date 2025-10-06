using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �W���C�X�e�B�b�N�̓������󂯎���ăv���C���[�J�����𓮂���
/// </summary>
public class PlayerCameraMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[��Object
    /// </summary>
    [SerializeField] private GameObject _player;

    /// <summary>
    /// �Q�Ƃ�����C���v�b�g�p�����[�^
    /// </summary>
    [SerializeField] private InputAction _moveAction;

    /// <summary>
    /// �W���C�X�e�B�b�N�̈ړ��ʒu
    /// </summary>
    private Vector2 _joyStickPostion;

    /// <summary>
    /// ���W���C�X�e�B�b�N�������Ă邩
    /// </summary>
    private bool _isJoyStickMove = false;

    void Start()
    {
        //�L��������
        _moveAction.Enable();
        //�W���C�X�`�F�b�N�𓮂������Ƃ�
        _moveAction.performed += _ =>
        {
            Vector2 value = _moveAction.ReadValue<Vector2>();
            _joyStickPostion = value;
            _isJoyStickMove = true;
        };
        //�W���C�X�e�B�b�N���~�܂�����
        _moveAction.canceled += _ =>
        {
            _isJoyStickMove = false;
        };
    }

    /// <summary>
    /// ��ɌĂ΂��
    /// </summary>
    void Update()
    {
        if(_isJoyStickMove)
		{
            //�v���C���[�̊p�x���󂯎��
            Vector3 angle = _player.transform.localEulerAngles;
            angle.x -= _joyStickPostion.y * Time.deltaTime * 50;
            angle.y += _joyStickPostion.x * Time.deltaTime * 50;
            //�ҏW��̊p�x������
            _player.transform.localEulerAngles = angle;
        }
    }
}
