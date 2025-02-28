using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDatabase", menuName = "Plant Database")]
public class PlantsDatabase : ScriptableObject
{
    public List<PlantData> PlantDataList;

    public Sprite HarvestIcon;
}