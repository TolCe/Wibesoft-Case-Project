using UnityEngine;

public class InventoryScreen : Screen
{
    [SerializeField] private BuildingDatabase _buildingDatabase;

    [SerializeField] private InventoryItem _prefab;
    [SerializeField] private Transform _container;

    private void Start()
    {
        ListInventory();

        ToggleScreen(false);
    }

    public void ListInventory()
    {
        foreach (BuildingData data in _buildingDatabase.BuildingDataList)
        {
            InventoryItem item = Instantiate(_prefab, _container);
            item.SetData(data);
        }
    }
}