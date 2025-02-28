using System;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : Building, IModifiable
{
    public Plant AttachedPlant { get; private set; }

    public void Modify(bool shouldPlant)
    {
        if (shouldPlant)
        {
            if (AttachedPlant == null)
            {
                AttachedPlant = PlantsPoolController.Instance.GetFromPool();
                AttachedPlant.Initialize(PlantsController.Instance.SelectedPlantData, transform.position);

                PlantsController.Instance.TakeAction();
            }
        }
        else
        {
            TryHarvesting();
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