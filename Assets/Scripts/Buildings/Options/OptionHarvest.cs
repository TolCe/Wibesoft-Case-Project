public class OptionHarvest : IBuildingOption
{
    public void ApplyOption(IModifiable modifiable)
    {
        modifiable.Modify(Enums.BuildingOptionTypes.Harvest);
    }
}
