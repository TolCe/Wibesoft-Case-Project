using System;
using UnityEngine;

public class PlantsController : Singleton<PlantsController>
{
    [SerializeField] private PlantsDatabase _database;
    public PlantsDatabase Database { get { return _database; } }

    public PlantData SelectedPlantData { get; private set; }

    public Action OnActionTaken;

    public void TakeAction()
    {
        OnActionTaken?.Invoke();
    }

    public void SetOptions(bool plantAttached)
    {
        BuildingOptionsScreen buildingOptionsScreen = (ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions) as BuildingOptionsScreen);

        buildingOptionsScreen.ToggleScreen(true);

        if (plantAttached)
        {
            buildingOptionsScreen.ListOptions(1);
            buildingOptionsScreen.CreatedOptionList[0].Initialize(Database.HarvestIcon);

            IBuildingOption buildingOption = new OptionHarvest();

            Action action = () =>
            {
                BuildingOptionsController.Instance.InitializeFollower(buildingOption, Database.HarvestIcon);
            };

            buildingOptionsScreen.CreatedOptionList[0].AddDragAction(action);
        }
        else
        {
            buildingOptionsScreen.ListOptions(Database.PlantDataList.Count);

            for (int i = 0; i < buildingOptionsScreen.CreatedOptionList.Count; i++)
            {
                buildingOptionsScreen.CreatedOptionList[i].Initialize(Database.PlantDataList[i].Icon);

                IBuildingOption buildingOption = new OptionPlantSeed();

                PlantData data = Database.PlantDataList[i];

                Action action = () =>
                {
                    SelectedPlantData = data;
                    BuildingOptionsController.Instance.InitializeFollower(buildingOption, data.Icon);
                };

                buildingOptionsScreen.CreatedOptionList[i].AddDragAction(action);
            }
        }
    }
}