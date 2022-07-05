using UnityEngine;
/// <summary>
/// Model of Entity
/// </summary>
public class EntityModel
{
    private EntityDescription _description;
    private string _information;
    private float _moveSpeed;

    public EntityDescription Description => _description;

    public EntityModel(EntityDescription description)
    {
        _description = description;
        _information = _description.Information;
        _moveSpeed = _description.MoveSpeed;
    }
    

}
