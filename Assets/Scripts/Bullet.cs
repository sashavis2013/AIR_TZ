using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Target { get => _target; set => _target = value; }
    private GameObject _target;

    private void Update()
    {
        UpdateRotation();
        UpdatePosition();
    }
    /// <summary>
    /// Changes rotation of gameObject's transform based on target's position
    /// </summary>
    private void UpdateRotation()
    {
        Vector3 targetDirection = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, GameManager.Instance.BulletRotationSpeed * Time.deltaTime);
    }
    /// <summary>
    /// /// <summary>
    /// Changes position of gameObject's transform based on target's position
    /// </summary>
    private void UpdatePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, GameManager.Instance.BulletSpeed * Time.deltaTime);
    }
    /// <summary>
    /// Destroys bullet if it hit a target
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Target target))
            gameObject.SetActive(false);
    }

}
