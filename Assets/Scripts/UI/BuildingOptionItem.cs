using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingOptionItem : MonoBehaviour, ISwipable
{
    [SerializeField] private EventTrigger _eventTrigger;

    [SerializeField] private Image _iconImage;

    public void Initialize(Sprite icon)
    {
        SetIcon(icon);

        transform.SetAsLastSibling();
    }

    public void AddDragAction(Action dragAction)
    {
        _eventTrigger.triggers.RemoveRange(0, _eventTrigger.triggers.Count);

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener((data) =>
        {
            dragAction?.Invoke();
        });

        _eventTrigger.triggers.Add(entry);
    }

    public void OnClick()
    {

    }

    public void OnDrag()
    {

    }

    private void SetIcon(Sprite icon)
    {
        gameObject.SetActive(true);
        _iconImage.sprite = icon;
    }
}