using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexagon;

public class StageCreator : MonoBehaviour
{
    #region Serialize
    [Header("ステージサイズ")]
    [SerializeField]
    Vector2Int _mapSize = new Vector2Int(5, 5);
    [Header("並べるタイルのPrefab")]
    [SerializeField]
    StageTile _tilePrefab = default;
    [SerializeField]
    int power = 5;
    #endregion

    /// <summary> ステージデータ </summary>
    Map _mapData = default;
    /// <summary> タイルリスト </summary>
    List<StageTile> _tileData = default;

    private void Awake()
    {
        _mapData = new Map(_mapSize.x, _mapSize.y);
        _tileData = new List<StageTile>();
    }
    private void Start()
    {
        foreach (var point in _mapData)
        {
            Point pointData = (Point)point;
            if (pointData != null)
            {
                var tile = Instantiate(_tilePrefab, transform);
                tile.StartSet(pointData,_mapSize.x);
                tile.OnSelectSearch += Search;
                _tileData.Add(tile);
            }
        }
    }
    public void Search(int point, Func<Point, Point, int> check)
    {
        foreach (var tile in _tileData)
        {
            tile.CloseTile();
        }
        _mapData.StartSearchExtent(point, power, check);
        for (int i = 0; i < _tileData.Count; i++)
        {
            if(_mapData[i].MoveCost >= 0)
            {
                _tileData[i].SelectTile();
            }
        }
    }
}
