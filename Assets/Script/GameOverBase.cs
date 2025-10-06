using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���I�[�o�[�̋���
/// </summary>

public class GameOverBase : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverText;

    /// <summary>
    /// �Q�[���I�[�o�[�ɂȂ��Ă���̌o�ߎ���
    /// </summary>
    private float _gameOverTimer;

    /// <summary>
    /// �ŏ��ɌĂ΂��
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.SetActive(false);
    }
    /// <summary>
    /// ��ɌĂяo�����
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        ///�Q�[���I�[�o�[�e�L�X�g���\�����ꂽ�ꍇ
        if (_gameOverText.activeSelf)
        {
            _gameOverTimer += Time.deltaTime;
            if (_gameOverTimer >= 5.0f)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
    /// <summary>
    /// �Q�[���I�[�o�[���J�n����
    /// </summary>
    public void GameOverStart()
    {
        _gameOverText.SetActive(true);
    }

}
