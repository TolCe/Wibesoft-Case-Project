using UnityEngine;
using UnityEngine.UI;

public class BuildingOptionInputFollower : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Toggle(bool value)
    {
        gameObject.SetActive(value);
    }

    public void SetIcon(Sprite icon)
    {
        _image.sprite = icon;
    }

    public void Follow(Vector3 pos)
    {
        transform.position = pos;
    }
}