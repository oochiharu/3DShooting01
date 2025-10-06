using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// “G‚Ì¶¬ŠÇ—‚ğ‚·‚é
/// </summary>
public class EnemyManager : MonoBehaviour
{
    /// <summary>
    /// ƒRƒs[Œ³‚Ì“GObject
    /// </summary>
    [SerializeField] private EnemyBase _originalEnemy;

    /// <summary>
    /// ì¬‚ğ‚·‚é‚Ü‚Å‚ÌŠÔ
    /// </summary>
    private float _createTimer = 0;




    /// <summary>
    /// Å‰‚ÉŒÄ‚Î‚ê‚é
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// –ˆ‰ñŒÄ‚Î‚ê‚é
    /// </summary>
    void Update()
    {
        //5•bŒo‰ß‚µ‚Ä‚È‚¢‚È‚çæ‚Éi‚Ü‚È‚¢
        if (_createTimer < 5.0f)
		{
            _createTimer += Time.deltaTime;
            return;
		}
        _createTimer = 0;

        //“G‚Ì•¡»‚ğì‚é
        EnemyBase enemyBase = (EnemyBase)Instantiate(_originalEnemy,
            new Vector3(UnityEngine.Random.Range(-80.0f, 80.0f),
            UnityEngine.Random.Range(-60.0f, 80.0f),
            UnityEngine.Random.Range(20.0f, 180.0f)),
            Quaternion.identity
            );
        //‚±‚¿‚ç‚ğŒü‚©‚¹‚é
        enemyBase.gameObject.transform.LookAt(Camera.main.transform.localPosition);
    }
}
