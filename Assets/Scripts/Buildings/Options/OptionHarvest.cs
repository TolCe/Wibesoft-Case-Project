public class OptionHarvest : IBuildingOption
{
    public BuildingOptionData BuildingOptionData { get; private set; }

    public void SetData(BuildingOptionData data)
    {
        BuildingOptionData = data;
    }

    public void ApplyOption(IModifiable modifiable)
    {
        modifiable.Modify(Enums.BuildingOptionTypes.Harvest, BuildingOptionData);
    }
}
