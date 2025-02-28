using System.Collections;
using UnityEngine;

public class BuildingOptionsController : Singleton<BuildingOptionsController>
{
    [SerializeField] private BuildingOptionInputFollower _follower;

    private bool _followInput;

    public IBuildingOption Option { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        InputController.Instance.OnInputEnd += OnInputEnd;
    }
    private void Start()
    {
        _follower.Toggle(false);
    }

    public void OnInputEnd()
    {
        _followInput = false;

        Option = null;
    }

    public void InitializeFollower(BuildingOptionData data)
    {
        ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions).ToggleScreen(false);

        _follower.SetIcon(data.Icon);
        _follower.Toggle(true);

        switch (data.OptionType)
        {
            case Enums.BuildingOptionTypes.PlantSeed:

                Option = new OptionPlantSeed();

                break;
            case Enums.BuildingOptionTypes.Harvest:

                Option = new OptionHarvest();

                break;
        }

        Option.SetData(data);

        StartCoroutine(FollowerFollowMouse());
    }

    public void FollowInput()
    {
        _follower.FollowInput(InputController.Instance.GetInputPosition());
    }

    private IEnumerator FollowerFollowMouse()
    {
        _followInput = true;

        while (_followInput)
        {
            FollowInput();

            RaycastHit hit = InputController.Instance.CheckClickedItem();

            FarmPlot hitTile = hit.collider?.GetComponent<FarmPlot>();
            if (hitTile != null)
            {
                Option.ApplyOption(hitTile);
            }

            yield return new WaitForEndOfFrame();
        }

        _follower.Toggle(false);
    }
}