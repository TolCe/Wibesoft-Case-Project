using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingOptionItem : MonoBehaviour, ISwipable
{
    [SerializeField] private EventTrigger _eventTrigger;

    [SerializeField] private Image _iconImage;

    private void Start()
    {
    }

    public void AddDragAction(IBuildingOption buildingOption)
    {
        _eventTrigger.triggers.RemoveRange(0, _eventTrigger.triggers.Count);

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener((data) =>
        {
            BuildingOptionsController.Instance.InitializeFollower(buildingOption);
        });

        _eventTrigger.triggers.Add(entry);
    }

    public void OnClick()
    {

    }

    public void OnDrag()
    {

    }

    public void SetIcon(Sprite icon)
    {
        gameObject.SetActive(true);
        _iconImage.sprite = icon;
    }
}