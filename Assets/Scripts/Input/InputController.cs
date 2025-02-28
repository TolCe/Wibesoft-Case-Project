using System;
using UnityEngine;

public class InputController : Singleton<InputController>
{
    public Action OnInput;
    public Action OnInputEnd;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnInput?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CheckClickedItem();

            OnInputEnd?.Invoke();
        }
    }

    public Vector3 GetInputPosition()
    {
        return Input.mousePosition;
    }

    public RaycastHit CheckClickedItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IClickable clickable = hit.collider.GetComponent<IClickable>();

            clickable?.OnClicked();
        }

        return hit;
    }
}