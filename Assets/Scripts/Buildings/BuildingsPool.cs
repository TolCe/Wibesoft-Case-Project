using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsPool : Singleton<BuildingsPool>
{
    [SerializeField] private BuildingDatabase _buildingDatabase;

    [SerializeField] private Transform _container;

    private Dictionary<Enums.BuildingTypes, ObjectPool<Building>> _pools = new Dictionary<Enums.BuildingTypes, ObjectPool<Building>>();

    protected override void Awake()
    {
        base.Awake();

        CreatePool();
    }

    private void CreatePool()
    {
        foreach (BuildingDatabase.PrefabData data in _buildingDatabase.PrefabDataList)
        {
            ObjectPool<Building> pool = new ObjectPool<Building>(data.Prefab, 5, _container);
            _pools.Add(data.BuildingType, pool);
        }
    }

    public Building GetFromPool(Enums.BuildingTypes type)
    {
        return _pools[type].Get();
    }

    public void ReturnToPool(Building building)
    {
        _pools[building.BuildingData.BuildingType].Return(building);
    }
}