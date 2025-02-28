using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsController : Singleton<BuildingsController>
{
    [SerializeField] private BuildingDatabase _buildingDatabase;

    public BuildingData SelectedBuildingData { get; private set; }
    public Building SelectedBuilding { get; private set; }

    public List<Building> PlacedBuildingsList { get; private set; }

    private bool _followInput;
    private Tile _selectedTile;

    private bool _placable;

    protected override void Awake()
    {
        base.Awake();

        PlacedBuildingsList = new List<Building>();

        InputController.Instance.OnInputEnd += OnInputEnd;
    }

    public void GetNewPlacable(Enums.BuildingTypes type)
    {
        SelectedBuilding = BuildingsPool.Instance.GetFromPool(type);
    }

    public void InitializePlacable(Enums.BuildingTypes type)
    {
        foreach (Building building in PlacedBuildingsList)
        {
            building.ToggleCollider(false);
        }

        ScreenController.Instance.GetScreen(Enums.ScreenTypes.Inventory).ToggleScreen(false);

        GetNewPlacable(type);
        SelectedBuilding.Initialize(_buildingDatabase.BuildingDataList.Find(x => x.BuildingType == type));
        StartCoroutine(FollowerFollowMouse());
    }

    public void OnInputEnd()
    {
        _followInput = false;

        if (_selectedTile != null)
        {
            if (_placable)
            {
                PlaceToTile();
            }
            else
            {
                BuildingsPool.Instance.ReturnToPool(SelectedBuilding);
            }

            SelectedBuilding = null;
            _selectedTile = null;
        }
    }

    private IEnumerator FollowerFollowMouse()
    {
        _followInput = true;

        while (_followInput)
        {
            RaycastHit hit = InputController.Instance.CheckClickedItem();

            Tile hitTile = hit.collider?.GetComponent<Tile>();
            if (hitTile != null)
            {
                _selectedTile = hitTile;

                if (_selectedTile != null)
                {
                    SnapToTile(_selectedTile);
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void SnapToTile(Tile tile)
    {
        if (tile.CanSnap((int)SelectedBuilding.Size.y - 1, (int)SelectedBuilding.Size.x - 1))
        {
            SelectedBuilding.OnSnapped(tile);
            CheckSnapSuccess();
        }
    }

    public void PlaceToTile()
    {
        PlacedBuildingsList.Add(SelectedBuilding);

        for (int i = 0; i < (int)SelectedBuilding.Size.y; i++)
        {
            for (int j = 0; j < (int)SelectedBuilding.Size.x; j++)
            {
                GridController.Instance.Tiles[(int)(_selectedTile.Coords.y - i), (int)(_selectedTile.Coords.x + j)].AttachItem(SelectedBuilding);
            }
        }

        foreach (Building building in PlacedBuildingsList)
        {
            building.ToggleCollider(true);
        }
    }

    private void CheckSnapSuccess()
    {
        _placable = true;

        for (int i = 0; i < (int)SelectedBuilding.Size.y; i++)
        {
            for (int j = 0; j < (int)SelectedBuilding.Size.x; j++)
            {
                if (GridController.Instance.Tiles[(int)(_selectedTile.Coords.y - i), (int)(_selectedTile.Coords.x + j)].CheckIfItemAttached())
                {
                    _placable = false;

                    break;
                }
            }
        }

        if (!_placable)
        {
            Color color = Color.red;
            color.a = 0.5f;
            SelectedBuilding.SetMaterialColor(color);
        }
        else
        {
            SelectedBuilding.ResetMaterialColor();
        }
    }
}