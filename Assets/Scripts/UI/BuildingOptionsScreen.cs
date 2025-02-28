using System.Collections.Generic;
using UnityEngine;

public class BuildingOptionsScreen : Screen
{
    private void Start()
    {
        ToggleScreen(false);
    }

    public void ListOptions(List<BuildingOptionData> optionList)
    {
        foreach (BuildingOptionData option in optionList)
        {
            BuildingOptionItem item = BuildingOptionsPool.Instance.GetFromPool();
            item.SetData(option);
        }
    }
}