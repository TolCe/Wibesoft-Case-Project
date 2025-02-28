using System;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : Building, IModifiable
{
    public Plant AttachedPlant { get; private set; }

    public void Modify(Enums.BuildingOptionTypes optionType)
    {
        switch (optionType)
        {
            case Enums.BuildingOptionTypes.PlantSeed:

                if (AttachedPlant == null)
                {
                    AttachedPlant = PlantsPoolController.Instance.GetFromPool();
                    AttachedPlant.Initialize(transform.position);
                }

                break;
            case Enums.BuildingOptionTypes.Harvest:

                TryHarvesting();

                break;
            default:
                break;
        }
    }

    public override void OnClicked()
    {
        if (!BuildingOptionsController.Instance.FollowingInput)
        {
            base.OnClicked();

            BuildingOptionsScreen buildingOptionsScreen = (ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions) as BuildingOptionsScreen);

            buildingOptionsScreen.ToggleScreen(true);
            buildingOptionsScreen.ListOptions(PlantsController.Instance.Database.PlantDataList.Count);

            List<BuildingOptionItem> list = new List<BuildingOptionItem>(buildingOptionsScreen.CreatedOptionList);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetIcon(PlantsController.Instance.Database.PlantDataList[i].Icon);

                IBuildingOption buildingOption = AttachedPlant != null ? new OptionHarvest() : new OptionPlantSeed();

                list[i].AddDragAction(buildingOption);
            }
        }
    }

    public void TryHarvesting()
    {
        if (AttachedPlant == null)
        {
            return;
        }
    }
}