using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// タイトルのUI制御・主にmainシーンへの遷移
/// </summary>
public class TitleUI : MonoBehaviour
{
    /// <summary>
    /// スタートボタン
    /// </summary>
    [SerializeField] private Button _gameStartButton;

    /// <summary>
    /// プレイヤーキャラのアニメ
    /// </summary>
    [SerializeField] private Animator _playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation.SetBool("Opening", true);
        //ボタンを押したとき
        _gameStartButton.onClick.AddListener(() =>
        {
            //mainシーンに遷移
            SceneManager.LoadScene("main");
        });
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
