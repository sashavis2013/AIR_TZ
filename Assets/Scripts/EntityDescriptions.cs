using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ScriptableObject to insert data in Models of Entities
/// </summary>
[CreateAssetMenu(fileName = "EntityDescriptions", menuName = "EntityDescriptions", order = 51)]
public class EntityDescriptions : ScriptableObject
{
    [SerializeField] private List<EntityDescription> _targetList;
    public List<EntityDescription> TargetList => _targetList;
}
