using UnityEngine;

public class FarmPlot : Building, IModifiable
{
    public Plant AttachedPlant { get; private set; }

    public void Modify(Enums.BuildingOptionTypes optionType, BuildingOptionData optionData)
    {
        switch (optionType)
        {
            case Enums.BuildingOptionTypes.PlantSeed:

                if (AttachedPlant == null)
                {
                    AttachedPlant = PlantsPoolController.Instance.GetFromPool();
                }

                break;
            case Enums.BuildingOptionTypes.Harvest:
                break;
            default:
                break;
        }
    }

    public override void OnClicked()
    {
        if (BuildingOptionsController.Instance.Option != null)
        {
            return;
        }

        base.OnClicked();

        ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions).ToggleScreen(true);
        (ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions) as BuildingOptionsScreen).ListOptions(BuildingData.BuildingOptionList);
    }
}