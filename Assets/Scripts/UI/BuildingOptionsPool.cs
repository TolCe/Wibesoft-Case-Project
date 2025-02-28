using System.Collections.Generic;
using System;
using UnityEngine;

public class BuildingOptionsPool : Singleton<BuildingOptionsPool>
{
    [SerializeField] private Transform _container;
    [SerializeField] private BuildingOptionItem _prefab;

    ObjectPool<BuildingOptionItem> _pool;

    protected override void Awake()
    {
        base.Awake();

        CreatePool();
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<BuildingOptionItem>(_prefab, 5, _container);
    }

    public BuildingOptionItem GetFromPool()
    {
        return _pool.Get();
    }

    public void ReturnToPool(BuildingOptionItem item)
    {
        _pool.Return(item);
    }

    public void ReturnAllToPool()
    {
        _pool.ReturnAll();
    }
}