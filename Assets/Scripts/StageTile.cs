using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexagon;

public class StageTile : MonoBehaviour
{
    #region Serialize
    [Tooltip("�^�C������")]
    [SerializeField]
    float _tileWide = 1f;
    [Tooltip("�I��\��")]
    [SerializeField]
    GameObject _selectMark = default;
    #endregion

    #region Property
    /// <summary> �X�e�[�W�̍ő�X���W </summary>
    private int _maxX = default;
    /// <summary> �X�e�[�WX���W </summary>
    public int X { get; private set; }
    /// <summary> �X�e�[�WY���W </summary>
    public int Y { get; private set; }
    /// <summary> �X�e�[�W���W </summary>
    public int Point { get => X + Y * _maxX; }
    #endregion

    #region PublicMethod
    /// <summary>
    /// �����ݒ�
    /// </summary>
    /// <param name="point"></param>
    public void StartSet(Point point,int maxX)
    {
        X = point.X;
        Y = point.Y;
        _maxX = maxX;
        transform.position = HexagonPos(X, Y);
    }
    public void SelectTile()
    {
        _selectMark.SetActive(true);
    }
    public void CloseTile()
    {
        _selectMark.SetActive(false);
    }
    public int PointMoveCost(Point point,Point beforePoint)
    {
        int cost = 0;
        if (point.MoveCost >= beforePoint.MoveCost)
        {
            return -1;
        }

        return cost;
    }
    #endregion

    #region PrivatMethod
    /// <summary>
    /// �w����W�̘Z�p�`�̍��W��Ԃ�
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private Vector3 HexagonPos(float x, float y)
    {
        var hexagonH = _tileWide * Mathf.Sin(60.0f * Mathf.Deg2Rad);

        // X�����̂���
        var adjust = _tileWide * Mathf.Cos(60.0f * Mathf.Deg2Rad);

        float gridX = _tileWide * x + adjust * Mathf.Abs(y % 2);
        float gridY = hexagonH * y;
        return new Vector3(gridX, 0, gridY);
    }
    #endregion
}
