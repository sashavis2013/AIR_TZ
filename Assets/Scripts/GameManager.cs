using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float BulletRotationSpeed;
    public float BulletSpeed;
    public float ShootCoolDown;
    public List<GameObject> Targets;
    [SerializeField] private EntityDescriptions _entityDescriptions;

    private Factory _factory;
    [SerializeField]private GameObject _targetPrefab;
    [SerializeField]private int _targetAmount;
    private int _shotTargets;
    private void Start()
    {
        _factory = new Factory();
        _factory.Init(_entityDescriptions);

        for (int i = 0; i < _targetAmount; i++)
        {
            var target = _factory.CreateMobModel("Target", 0);
            GameObject go = Instantiate(_targetPrefab);
            go.name = $"Target {i}";

            go.GetComponent<Target>().MoveSpeed=target.Description.MoveSpeed;
            Targets.Add(go);
        }

    }

    private void Update()
    {
        CheckTargets();
    }
    /// <summary>
    /// Checks if all targets got hit, and if so, resets them all
    /// </summary>
    private void CheckTargets()
    {
        _shotTargets = 0;

        foreach (var target in Targets)
        {
            if (target.GetComponent<Target>().IsShot)
                _shotTargets++;
        }
        if (_shotTargets == Targets.Count)
        {
            foreach (var target in Targets)
            {
                target.GetComponent<Target>().IsShot = false;
            }
        }
    }

}