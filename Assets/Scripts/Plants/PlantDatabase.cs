using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDatabase", menuName = "Plant Database")]
public class PlantDatabase : ScriptableObject
{
    public List<PlantData> PlantDataList;
}