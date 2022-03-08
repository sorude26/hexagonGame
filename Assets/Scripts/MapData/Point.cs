using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 探索用座標状態
/// </summary>
public enum PointState
{
    Floor,
    Wall,
    Start,
    Goal,
    Open,
    Close,
}
/// <summary>
/// 地形種類
/// </summary>
public enum TerrainType
{
    Normal,
    NoneEntry,
}
namespace Hexagon
{
    /// <summary>
    /// 座標データ
    /// </summary>
    public class Point
    {
        /// <summary> 座標X </summary>
        public int X { get; set; }
        /// <summary> 座標Y </summary>
        public int Y { get; set; }
        /// <summary> 高度 </summary>
        public int Level { get; set; }
        /// <summary> 地形種類 </summary>
        public TerrainType Type { get; set; }
        /// <summary> 探索用スコア </summary>
        public int Score { get; set; }
        /// <summary> 探索用コスト </summary>
        public int Cost { get; set; }
        /// <summary> 探索用実コスト </summary>
        public int MoveCost { get; set; }
        /// <summary> 座標の状態 </summary>
        public PointState State { get; set; }
        /// <summary> 探索用親データ </summary>
        public Point Parent { get; set; }
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}