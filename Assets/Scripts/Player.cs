using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private bool _isOnCD;
    private void Awake()
    {
        _transform = gameObject.transform;
    }
    /// <summary>
    /// Method to get a bullet from object pool and launch it towards target
    /// </summary>
    /// <param name="target">Target to shoot at</param>
    private void Shoot(Transform target)
    {
        
        GameObject bullet = BulletObjectPool.Instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().Target = target.gameObject;
            CooldownStart();
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            TryShoot();
        if (Input.touchCount>0)
            TryShoot();
    }
    /// <summary>
    /// Checks if player can shoot and does it if he can
    /// </summary>
    private void TryShoot()
    {
        if (_isOnCD) return;
        for (int i = 0; i < GameManager.Instance.Targets.Count; i++)
        {
            if (GameManager.Instance.Targets[i].GetComponent<Target>().IsShot)
                continue;
            Shoot(GameManager.Instance.Targets[i].transform);
            GameManager.Instance.Targets[i].GetComponent<Target>().IsShot = true;
            break;
        }
    }
    /// <summary>
    /// Cooldown mechanic for weapon
    /// </summary>
    ///
    //(Could be moven into separate script)
    private void CooldownStart()
    {
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        _isOnCD = true;
        yield return new WaitForSeconds(GameManager.Instance.ShootCoolDown);
        _isOnCD = false;
    }

}
