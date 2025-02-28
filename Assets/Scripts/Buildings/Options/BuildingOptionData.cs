using UnityEngine;

[CreateAssetMenu(fileName = "BuildingOption_", menuName = "Building Option Data")]
public class BuildingOptionData : ScriptableObject
{
    public Enums.BuildingOptionTypes OptionType;
    public Sprite Icon;
}