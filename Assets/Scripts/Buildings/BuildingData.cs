using UnityEngine;

[CreateAssetMenu(fileName = "Building_", menuName = "Building Data")]
public class BuildingData : ScriptableObject
{
    public Enums.BuildingTypes BuildingType;

    public Sprite Icon;

    public Vector2 Size = new Vector2 { x = 1, y = 1 };
}