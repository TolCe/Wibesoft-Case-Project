using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDatabase", menuName = "Building/Building Database")]
public class BuildingDatabase : ScriptableObject
{
    [SerializeField] private List<BuildingData> _buildingDataList;
    public List<BuildingData> BuildingDataList { get { return _buildingDataList; } }

    [SerializeField] private List<PrefabData> _prefabDataList;
    public List<PrefabData> PrefabDataList { get { return _prefabDataList; } }

    [Serializable]
    public struct PrefabData
    {
        public Enums.BuildingTypes BuildingType;
        public Building Prefab;
    }
}