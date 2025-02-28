using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Transform _scaleTransform;

    [SerializeField] private Renderer _rend;

    private PlantData _plantData;

    private float _harvestTimer;

    public bool ReadyForHarvest { get { return _harvestTimer >= _plantData.HarvestTime; } }

    public void Initialize(PlantData data, Vector3 position)
    {
        _plantData = data;

        gameObject.SetActive(true);

        SetPosition(position);
        SetColor(data.Color);
    }

    private void Update()
    {
        if (_plantData != null)
        {
            _harvestTimer += Time.deltaTime;
            _harvestTimer = Mathf.Clamp(_harvestTimer, 0, _plantData.HarvestTime);
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
        _plantData = null;
        _harvestTimer = 0;

        PlantsPoolController.Instance.ReturnToPool(this);
    }

    private void SetPlantFilling()
    {
        _scaleTransform.localScale = new Vector3(1, _harvestTimer / _plantData.HarvestTime, 1);
    }
}