using UnityEngine;

public class PlantsController : Singleton<PlantsController>
{
    [SerializeField] private PlantsDatabase _database;
    public PlantsDatabase Database { get { return _database; } }

    public PlantData GetPlantDataByType(Enums.PlantTypes plantType)
    {
        return _database.PlantDataList.Find(x => x.PlantType == plantType);
    }
}