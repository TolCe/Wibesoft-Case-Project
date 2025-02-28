using UnityEngine;

public class Tile : MonoBehaviour
{
    private ITilable _attachedItem;

    public Vector2 Coords { get; private set; }

    public Vector3 Position { get { return transform.position; } }

    public void Initialize(Vector2 coords)
    {
        Coords = coords;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void AttachItem(ITilable item)
    {
        _attachedItem = item;
    }

    public bool CheckIfItemAttached()
    {
        return _attachedItem != null;
    }

    public bool CanSnap(int height, int width)
    {
        if (Coords.x + width >= GridController.Instance.Tiles.GetLength(1) || Coords.y - height < 0)
        {
            return false;
        }

        return true;
    }
}
