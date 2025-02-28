using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;

    public void Initialize(PlantData data)
    {
        SetIcon(data.Icon);
    }

    public void SetIcon(Sprite sprite)
    {
        _rend.sprite = sprite;
    }
}