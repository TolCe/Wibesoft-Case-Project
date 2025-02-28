using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, ISwipable
{
    [SerializeField] private EventTrigger _eventTrigger;

    [SerializeField] private Image _iconImage;

    private BuildingData _data;

    private void Start()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener((data) => { OnDrag(); });

        _eventTrigger.triggers.Add(entry);
    }

    public void OnClick()
    {

    }

    public void OnDrag()
    {
        BuildingsController.Instance.InitializePlacable(_data.BuildingType);
    }

    public void SetData(BuildingData data)
    {
        _data = data;

        SetIcon(_data.Icon);
    }

    public void SetIcon(Sprite sprite)
    {
        _iconImage.sprite = sprite;
    }
}