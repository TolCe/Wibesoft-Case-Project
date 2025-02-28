using UnityEngine;

public class Building : MonoBehaviour, ITilable, IClickable
{
    [SerializeField] private Vector2 _size = new Vector2(1, 1);
    public Vector2 Size { get { return _size; } }

    [SerializeField] private Collider _collider;

    [SerializeField] private Renderer _rend;

    private Color _defaultColor;

    public BuildingData BuildingData { get; private set; }

    private void Awake()
    {
        _defaultColor = _rend.material.color;
        _defaultColor.a = 1;
    }

    public void Initialize(BuildingData data)
    {
        BuildingData = data;

        gameObject.SetActive(true);

        ToggleCollider(false);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void OnSnapped(Tile tile)
    {
        SetPosition(tile.Position);
    }

    public virtual void OnClicked()
    {

    }

    public void ToggleCollider(bool value)
    {
        _collider.enabled = value;
    }

    public void SetMaterialColor(Color color)
    {
        _rend.material.color = color;
    }

    public void ResetMaterialColor()
    {
        _rend.material.color = _defaultColor;
    }
}
