using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexagon;

public class StageTile : MonoBehaviour
{
    #region Serialize
    [Tooltip("タイル横幅")]
    [SerializeField]
    float _tileWide = 1f;
    [Tooltip("選択表示")]
    [SerializeField]
    GameObject _selectMark = default;
    #endregion

    #region PrivateField
    /// <summary> 移動コスト </summary>
    private int _cost = 1;
    #endregion

    #region Property
    /// <summary> ステージの最大X座標 </summary>
    private int _maxX = default;
    /// <summary> ステージX座標 </summary>
    public int X { get; private set; }
    /// <summary> ステージY座標 </summary>
    public int Y { get; private set; }
    /// <summary> ステージ座標 </summary>
    public int Point { get => X + Y * _maxX; }
    #endregion

    #region Event
    /// <summary> 探索選択時のイベント </summary>
    public event Action<int, Func<Point, Point, int>> OnSelectSearch;
    #endregion

    #region PublicMethod
    /// <summary>
    /// 初期設定
    /// </summary>
    /// <param name="point"></param>
    public void StartSet(Point point,int maxX)
    {
        X = point.X;
        Y = point.Y;
        _maxX = maxX;
        transform.position = HexagonPos(X, Y);
    }
    public void StartSearch()
    {
        OnSelectSearch?.Invoke(Point, PointMoveCost);
    }
    public void SelectTile()
    {
        _selectMark.SetActive(true);
    }
    public void CloseTile()
    {
        _selectMark.SetActive(false);
    }
    /// <summary>
    /// 移動コストを返す
    /// </summary>
    /// <param name="point"></param>
    /// <param name="beforePoint"></param>
    /// <returns></returns>
    public int PointMoveCost(Point point,Point beforePoint)
    {
        if (point.MoveCost >= beforePoint.MoveCost)
        {
            return -1;
        }
        return _cost;
    }
    #endregion

    #region PrivatMethod
    /// <summary>
    /// 指定座標の六角形の座標を返す
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private Vector3 HexagonPos(float x, float y)
    {
        var hexagonH = _tileWide * Mathf.Sin(60.0f * Mathf.Deg2Rad);

        // X方向のずれ
        var adjust = _tileWide * Mathf.Cos(60.0f * Mathf.Deg2Rad);

        float gridX = _tileWide * x + adjust * Mathf.Abs(y % 2);
        float gridY = hexagonH * y;
        return new Vector3(gridX, 0, gridY);
    }
    #endregion

    #region UnityCallback
    private void OnMouseDown()
    {
        StartSearch();
    }
    #endregion
}
