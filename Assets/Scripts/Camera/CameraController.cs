using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public Camera MainCamera { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        SetCamera();
    }

    private void SetCamera()
    {
        MainCamera = Camera.main;
    }
}