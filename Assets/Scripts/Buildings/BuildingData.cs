using UnityEngine;

[CreateAssetMenu(fileName = "Building_", menuName = "Building/Building Data")]
public class BuildingData : ScriptableObject
{
    [SerializeField] Enums.BuildingTypes _buildingType;
    public Enums.BuildingTypes BuildingType { get { return _buildingType; } }

    [SerializeField] Sprite _icon;
    public Sprite Icon { get { return _icon; } }

    [SerializeField] private Vector2 _size = new Vector2 { x = 1, y = 1 };
    public Vector2 Size { get { return _size; } }
}