using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の挙動を制御
/// </summary>
public class EnemyBase : MonoBehaviour
{
    /// <summary>
    /// 敵の体力
    /// </summary>
    public int LifePoint = 3;

    /// <summary>
    /// 射撃間隔のためのタイマー
    /// </summary>
    private float _timer = 0;

    [SerializeField] private GameObject _shotOriginal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 毎回処理をする
    /// </summary>
    void Update()
    {
        _timer += Time.deltaTime;
        //9秒に一回動作させる
        if (_timer <= 9.0f)
        {
            return;
        }
        _timer = 0;
        //射撃を行う

        //射撃のクローンを作成
        GameObject shotClone = (GameObject)Instantiate(_shotOriginal, transform.localPosition, Quaternion.identity);
        //カメラのほうを向かせる
        shotClone.transform.LookAt(Camera.main.transform.localPosition);
        //AddForceで打ち出す
        Rigidbody shotRigidBody = shotClone.gameObject.GetComponent<Rigidbody>();
        //カメラの向きの方向へパワーを加える
        shotRigidBody.AddForce(shotClone.transform.forward * 1000);
    }

    /// <summary>
    /// 何かにぶつかったら動作
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
        //敵以外に当たったら
		if (other.tag != "Enemy")
		{
            //体力が1減る
            LifePoint--;
            if(LifePoint == 0)
			{
                PlayerBase.GetInstance().AddScore(10);
                //体力0なので消滅
                Destroy(gameObject);
			}
        }
	}

}
