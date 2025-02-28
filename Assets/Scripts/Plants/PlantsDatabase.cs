using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDatabase", menuName = "Plant Database")]
public class PlantsDatabase : ScriptableObject
{
    [SerializeField] private List<PlantData> _plantDataList;
    public List<PlantData> PlantDataList { get { return _plantDataList; } }

    [SerializeField] private Sprite _harvestIcon;
    public Sprite HarvestIcon { get { return _harvestIcon; } }
}