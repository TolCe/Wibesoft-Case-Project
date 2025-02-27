using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public ITilable AttachedItem { get; private set; }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public virtual void OnTileHover()
    {

    }
}
