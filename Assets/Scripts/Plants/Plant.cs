using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;

    public void Initialize(Vector3 position)
    {
        gameObject.SetActive(true);

        SetPosition(position);
    }

    public void SetIcon(Sprite sprite)
    {
        _rend.sprite = sprite;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}