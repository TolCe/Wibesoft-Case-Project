using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreen : Screen
{
    [SerializeField] private Button _inventoryButton;

    private void Start()
    {
        _inventoryButton.onClick.AddListener(OnInventoryButtonClicked);
    }

    private void OnInventoryButtonClicked()
    {
        ScreenController.Instance.GetScreen(Enums.ScreenTypes.Inventory).ToggleScreen(true);
    }
}
