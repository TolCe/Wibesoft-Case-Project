using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    [SerializeField] private Enums.ScreenTypes _screenType;
    public Enums.ScreenTypes ScreenType { get { return _screenType; } }

    [SerializeField] private GameObject _panelGO;

    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _closeButton?.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        ToggleScreen(false);
    }

    public void ToggleScreen(bool value)
    {
        _panelGO.SetActive(value);
    }
}