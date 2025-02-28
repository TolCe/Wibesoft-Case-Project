using UnityEngine;

[CreateAssetMenu(fileName = "Plant_", menuName = "Plant Data")]
public class PlantData : ScriptableObject
{
    [SerializeField] private Enums.PlantTypes _plantType;
    public Enums.PlantTypes PlantType { get { return _plantType; } }

    [SerializeField] private Sprite _icon;
    public Sprite Icon { get { return _icon; } }

    [SerializeField] private Color _color;
    public Color Color { get { return _color; } }

    [SerializeField] private float _harvestTime = 1f;
    public float HarvestTime { get { return _harvestTime; } }
}