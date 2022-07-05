using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
[RequireComponent(typeof(Movement))]
public class Target : MonoBehaviour
{
    public bool IsShot=false;
    private Vector2 _startPosition;
    private float _roamRadius = 5;
    private float _moveSpeed;
    private Transform _transform;

    private Movement _movement;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    private void Awake()
    {
        _movement = gameObject.GetComponent<Movement>();
        _transform = gameObject.transform;
        _startPosition = GetStartingPosition();
        SetStartingPosition();
    }
    /// <summary>
    /// Gets a new random spawn position within visible coords
    /// </summary>
    /// <returns></returns>
    private Vector2 GetStartingPosition()
    {
        int randX = Random.Range(-9, 10);
        int randY = Random.Range(-3, 4);
        Vector2 pos = new Vector2(randX, randY);
        return pos;
    }

    private void SetStartingPosition()
    {
        _transform.position = _startPosition;
    }

    private void Update()
    {
         _movement.FreeRoam(_moveSpeed, _startPosition, _roamRadius);
    }
    private void Start()
    {
        _movement.FreeRoam(_moveSpeed, _startPosition, _roamRadius);

    }
    //In case another target got hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
            IsShot=true;
    }

}
