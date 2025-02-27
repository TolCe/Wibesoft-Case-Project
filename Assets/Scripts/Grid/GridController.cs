using UnityEngine;

public class GridController : Singleton<GridController>
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _tileContainer;


    private Tile[,] _tiles;

    [SerializeField] private int _tileWidth;
    [SerializeField] private int _tileHeight;

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        _tiles = new Tile[_tileHeight, _tileWidth];

        for (int i = 0; i < _tileHeight; i++)
        {
            for (int j = 0; j < _tileWidth; j++)
            {
                _tiles[i, j] = Instantiate(_tilePrefab, _tileContainer);
                _tiles[i, j].SetPosition(new Vector3(i, 0, j));
            }
        }
    }
}
