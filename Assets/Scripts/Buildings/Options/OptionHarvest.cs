public class OptionHarvest : IBuildingOption
{
    public void ApplyOption(IModifiable modifiable)
    {
        modifiable.Modify(false);
    }
}
