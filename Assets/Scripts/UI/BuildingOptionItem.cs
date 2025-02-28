using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingOptionItem : MonoBehaviour, ISwipable
{
    [SerializeField] private EventTrigger _eventTrigger;

    [SerializeField] private Image _iconImage;

    [SerializeField] private BuildingOptionData _data;

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
        BuildingOptionsController.Instance.InitializeFollower(_data);
    }

    public void SetData(BuildingOptionData data)
    {
        _data = data;

        SetIcon();

        gameObject.SetActive(true);
    }

    public void SetIcon()
    {
        _iconImage.sprite = _data.Icon;
    }
}