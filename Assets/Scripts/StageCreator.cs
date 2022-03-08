using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour
{
    #region Serialize
    [Header("ステージサイズ")]
    [SerializeField]
    Vector2Int _mapSize = new Vector2Int(5, 5);
    [Header("並べるタイルのPrefab")]
    [SerializeField]
    StageTile _tilePrefab = default;
    #endregion

    /// <summary> ステージデータ </summary>
    Hexagon.Map _mapData = default;
    /// <summary> タイルリスト </summary>
    List<StageTile> _tileData = default;

    private void Awake()
    {
        _mapData = new Hexagon.Map(_mapSize.x, _mapSize.y);
        _tileData = new List<StageTile>();
    }
    void Start()
    {
        foreach (var point in _mapData)
        {
            Hexagon.Point pointData = (Hexagon.Point)point;
            if (pointData != null)
            {
                var tile = Instantiate(_tilePrefab, transform);
                tile.StartSet(pointData,_mapSize.x);
                _tileData.Add(tile);
            }
        }
    }
}
