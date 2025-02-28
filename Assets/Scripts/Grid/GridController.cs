using UnityEngine;

public class GridController : Singleton<GridController>
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _tileContainer;


    private Tile[,] _tiles;
    public Tile[,] Tiles { get { return _tiles; } }

    [SerializeField] private int _tileWidth;
    [SerializeField] private int _tileHeight;

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        _tiles = new Tile[_tileHeight, _tileWidth];

        Vector3 initPos = new Vector3(-(_tileWidth - 1) * 0.5f, 0, (_tileHeight - 1) * 0.5f);

        for (int i = 0; i < _tileHeight; i++)
        {
            for (int j = 0; j < _tileWidth; j++)
            {
                _tiles[i, j] = Instantiate(_tilePrefab, _tileContainer);
                _tiles[i, j].Initialize(new Vector2(j, i));
                _tiles[i, j].SetPosition(initPos + new Vector3(j, 0, -i));
            }
        }
    }
}
