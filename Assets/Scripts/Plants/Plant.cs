using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Transform _scaleTransform;

    [SerializeField] private Renderer _rend;

    public PlantData PlantData { get; private set; }

    public float HarvestTimer { get; private set; }

    public bool ReadyForHarvest { get { return HarvestTimer >= PlantData.HarvestTime; } }

    public void Initialize(PlantData data, Vector3 position)
    {
        PlantData = data;

        gameObject.SetActive(true);

        SetPosition(position);
        SetColor(data.Color);
    }

    private void Update()
    {
        if (PlantData != null)
        {
            HarvestTimer += Time.deltaTime;
            HarvestTimer = Mathf.Clamp(HarvestTimer, 0, PlantData.HarvestTime);
            SetPlantFilling();
        }
    }

    private void SetColor(Color color)
    {
        _rend.material.color = color;
    }

    private void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void OnHarvest()
    {
        PlantData = null;
        HarvestTimer = 0;
        PlantsPoolController.Instance.ReturnToPool(this);
    }

    private void SetPlantFilling()
    {
        _scaleTransform.localScale = new Vector3(1, HarvestTimer / PlantData.HarvestTime, 1);
    }
}