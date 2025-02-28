using System;
using System.Collections;
using UnityEngine;

public class BuildingOptionsController : Singleton<BuildingOptionsController>
{
    [SerializeField] private BuildingOptionInputFollower _follower;

    public bool FollowingInput { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        InputController.Instance.OnInputEnd += OnInputEnd;
        PlantsController.Instance.OnActionTaken += OnActionTaken;
    }

    private void Start()
    {
        _follower.Toggle(false);
    }

    public void OnInputEnd()
    {
        FollowingInput = false;
    }

    private void OnActionTaken()
    {
        FollowingInput = false;
    }

    public void InitializeFollower(IBuildingOption option, Sprite icon)
    {
        ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions).ToggleScreen(false);

        _follower.Toggle(true);
        _follower.SetIcon(icon);

        StartCoroutine(FollowerFollowMouse(option));
    }

    private IEnumerator FollowerFollowMouse(IBuildingOption option)
    {
        FollowingInput = true;

        while (FollowingInput)
        {
            _follower.Follow(InputController.Instance.GetInputPosition());

            RaycastHit hit = InputController.Instance.CheckClickedItem();

            FarmPlot hitTile = hit.collider?.GetComponent<FarmPlot>();
            if (hitTile != null)
            {
                option.ApplyOption(hitTile);
            }

            yield return new WaitForEndOfFrame();
        }

        _follower.Toggle(false);
    }
}