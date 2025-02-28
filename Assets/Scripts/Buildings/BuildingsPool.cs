using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsPool : Singleton<BuildingsPool>
{
    [SerializeField] private Transform _container;
    [SerializeField] private List<PrefabData> _prefabDataList;

    private Dictionary<Enums.BuildingTypes, ObjectPool<Building>> _pools = new Dictionary<Enums.BuildingTypes, ObjectPool<Building>>();

    protected override void Awake()
    {
        base.Awake();

        CreatePool();
    }

    private void CreatePool()
    {
        foreach (PrefabData data in _prefabDataList)
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

    [Serializable]
    public struct PrefabData
    {
        public Enums.BuildingTypes BuildingType;
        public Building Prefab;
    }
}