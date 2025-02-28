using UnityEngine;

public class PlantsPoolController : Singleton<PlantsPoolController>
{
    [SerializeField] private Transform _container;
    [SerializeField] private Plant _prefab;

    ObjectPool<Plant> _pool;

    protected override void Awake()
    {
        base.Awake();

        CreatePool();
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<Plant>(_prefab, 5, _container);
    }

    public Plant GetFromPool()
    {
        return _pool.Get();
    }

    public void ReturnToPool(Plant item)
    {
        _pool.Return(item);
    }
}