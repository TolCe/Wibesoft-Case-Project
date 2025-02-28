using System.Collections.Generic;
using UnityEngine;

public class BuildingOptionsScreen : Screen
{
    public List<BuildingOptionItem> CreatedOptionList { get; private set; }

    private void Start()
    {
        ToggleScreen(false);

        CreatedOptionList = new List<BuildingOptionItem>();
    }

    public override void ToggleScreen(bool value)
    {
        base.ToggleScreen(value);

        if (!value)
        {
            CreatedOptionList = new List<BuildingOptionItem>();
            BuildingOptionsPool.Instance.ReturnAllToPool();
        }
    }

    public void ListOptions(int creationAmount)
    {
        for (int i = 0; i < creationAmount; i++)
        {
            BuildingOptionItem item = BuildingOptionsPool.Instance.GetFromPool();

            CreatedOptionList.Add(item);
        }
    }
}