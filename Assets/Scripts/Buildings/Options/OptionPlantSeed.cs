public class OptionPlantSeed : IBuildingOption
{
    public void ApplyOption(IModifiable modifiable)
    {
        modifiable.Modify(Enums.BuildingOptionTypes.PlantSeed);
    }
}
