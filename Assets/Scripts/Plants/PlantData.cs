using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant_", menuName = "Plant Data")]
public class PlantData : ScriptableObject
{
    public Enums.PlantTypes PlantType;

    public Sprite Icon;
}