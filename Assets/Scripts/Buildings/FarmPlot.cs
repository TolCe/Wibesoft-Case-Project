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
                    AttachedPlant.Initialize(PlantsController.Instance.SelectedPlantData, transform.position);

                    PlantsController.Instance.TakeAction();
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

            PlantsController.Instance.SetOptions(AttachedPlant != null);
        }
    }

    public void TryHarvesting()
    {
        if (AttachedPlant == null)
        {
            return;
        }

        if (AttachedPlant.ReadyForHarvest)
        {
            AttachedPlant.OnHarvest();
            AttachedPlant = null;

            PlantsController.Instance.TakeAction();
        }
    }
}