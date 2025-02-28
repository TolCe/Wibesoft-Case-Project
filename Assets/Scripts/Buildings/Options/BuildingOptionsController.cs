using System.Collections;
using UnityEngine;

public class BuildingOptionsController : Singleton<BuildingOptionsController>
{
    [SerializeField] private BuildingOptionInputFollower _follower;

    public bool FollowingInput {  get; private set; }

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
        FollowingInput = false;
    }

    public void InitializeFollower(IBuildingOption option)
    {
        ScreenController.Instance.GetScreen(Enums.ScreenTypes.BuildingOptions).ToggleScreen(false);

        _follower.Toggle(true);

        StartCoroutine(FollowerFollowMouse(option));
    }

    public void FollowInput()
    {
        _follower.FollowInput(InputController.Instance.GetInputPosition());
    }

    private IEnumerator FollowerFollowMouse(IBuildingOption option)
    {
        FollowingInput = true;

        while (FollowingInput)
        {
            FollowInput();

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

    public void ApplyBuildingOption()
    {

    }
}