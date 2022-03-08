using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour
{
    [Header("ステージサイズ")]
    [SerializeField]
    Vector2Int _mapSize = new Vector2Int(5, 5);
    [Header("並べるタイルのPrefab")]
    [SerializeField]
    GameObject _tilePrefab = default;
    [SerializeField]
    float _hexagonW = 1f;


    Hexagon.Map _mapData = default;
    private void Awake()
    {
        _mapData = new Hexagon.Map(_mapSize.x, _mapSize.y);
    }
    void Start()
    {
        foreach (var point in _mapData)
        {
            Hexagon.Point pointData = (Hexagon.Point)point;
            if (pointData != null)
            {
                var tile = Instantiate(_tilePrefab, transform);
                tile.transform.position = HexagonPos(pointData.X, pointData.Y);
            }
        }
    }

    Vector3 HexagonPos(float x, float y)
    {
        var hexagonH = _hexagonW * Mathf.Sin(60.0f * Mathf.Deg2Rad);

        // X方向のずれ
        var adjust = _hexagonW * Mathf.Cos(60.0f * Mathf.Deg2Rad);

        float gridX = _hexagonW * x + adjust * Mathf.Abs(y % 2);
        float gridY = hexagonH * y;

        return new Vector3(gridX,0,gridY);
    }
}
