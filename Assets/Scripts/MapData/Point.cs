using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �T���p���W���
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
/// �n�`���
/// </summary>
public enum TerrainType
{
    Normal,
    NoneEntry,
}
namespace Hexagon
{
    /// <summary>
    /// ���W�f�[�^
    /// </summary>
    public class Point
    {
        /// <summary> ���WX </summary>
        public int X { get; set; }
        /// <summary> ���WY </summary>
        public int Y { get; set; }
        /// <summary> ���x </summary>
        public int Level { get; set; }
        /// <summary> �n�`��� </summary>
        public TerrainType Type { get; set; }
        /// <summary> �T���p�X�R�A </summary>
        public int Score { get; set; }
        /// <summary> �T���p�R�X�g </summary>
        public int Cost { get; set; }
        /// <summary> �T���p���R�X�g </summary>
        public int MoveCost { get; set; }
        /// <summary> ���W�̏�� </summary>
        public PointState State { get; set; }
        /// <summary> �T���p�e�f�[�^ </summary>
        public Point Parent { get; set; }
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}