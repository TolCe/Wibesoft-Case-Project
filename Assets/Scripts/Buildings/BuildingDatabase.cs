using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDatabase", menuName = "Building Database")]
public class BuildingDatabase : ScriptableObject
{
    public List<BuildingData> BuildingDataList;
}