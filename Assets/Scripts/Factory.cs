using System;
using System.Collections.Generic;

public class Factory
{
    private Dictionary<string, Func<int, EntityModel>> _entityFactory;

    public void Init(EntityDescriptions descriptions)
    {
        _entityFactory = new Dictionary<string, Func<int, EntityModel>>()
        {
            {"Target", (preset) => new EntityModel(descriptions.TargetList[preset])}
        };

    }

    public EntityModel CreateMobModel(string entityName, int preset)
    {
        return _entityFactory[entityName](preset);
    }
}