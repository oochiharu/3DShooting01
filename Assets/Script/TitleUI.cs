using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// �^�C�g����UI����E���main�V�[���ւ̑J��
/// </summary>
public class TitleUI : MonoBehaviour
{
    /// <summary>
    /// �X�^�[�g�{�^��
    /// </summary>
    [SerializeField] private Button _gameStartButton;

    /// <summary>
    /// �v���C���[�L�����̃A�j��
    /// </summary>
    [SerializeField] private Animator _playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation.SetBool("Opening", true);
        //�{�^�����������Ƃ�
        _gameStartButton.onClick.AddListener(() =>
        {
            //main�V�[���ɑJ��
            SceneManager.LoadScene("main");
        });
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
