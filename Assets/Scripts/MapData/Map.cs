using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon
{
    /// <summary>
    /// �}�b�v�f�[�^
    /// </summary>
    public class Map :IEnumerable
    {
        /// <summary> �ő�X���W </summary>
        public int MaxX { get; }
        /// <summary> �ő�Y���W </summary>
        public int MaxY { get; }

        /// <summary> �S���W�f�[�^ </summary>
        public Point[] Data { get; private set; }
        public Map(int maxX,int maxY)
        {
            Data = new Point[maxX * maxY];
            MaxX = maxX;
            MaxY = maxY;
            CreateMap();
        }
        public Point this[int target]
        {
            get => Data[target];
        }
        public void StartSearchExtent(int point,int movePower,Func<Point,Point,int> check)
        {
            foreach (var dataPoint in Data)
            {
                dataPoint.MoveCost = -1;
            }
            Data[point].MoveCost = movePower;
            CheckNeighorPoint(point, movePower, check);
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// ���W�f�[�^�𐶐�����
        /// </summary>
        private void CreateMap()
        {
            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    Data[x + y * MaxX] = new Point(x, y);
                }
            }
        }
        private void CheckNeighorPoint(int point ,int movePower, Func<Point,Point, int> check)
        {
            foreach (var checkPoint in GetNeighorPoints(point))
            {
                CheckPoint(checkPoint, movePower, Data[point], check);
            }
        }
        private void CheckPoint(Point point, int movePower, Point beforePoint, Func<Point,Point, int> check)
        {
            int cost = check(point, beforePoint);
            if (cost >= 0 && cost <= movePower)
            {
                point.MoveCost = movePower - cost;
                CheckNeighorPoint(point.X + point.Y * MaxX, movePower - cost, check);
            }
        }
        /// <summary>
        /// �w����W�������6�����̍��W�f�[�^�Ԃ�
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private IEnumerable<Point> GetNeighorPoints(int point)
        {
            var start = Data[point];
            if (start.Y > 0)
            {
                if (start.Y % 2 != 0)
                {
                    if (start.X < MaxX - 1)
                    {
                        yield return this[point - MaxX + 1];
                    }
                }
                else
                {
                    if (start.X > 0)
                    {
                        yield return this[point - MaxX - 1];
                    }
                }
                yield return this[point - MaxX];
            }
            if (start.X > 0)
            {
                yield return this[point - 1];
            }
            if (start.X < MaxX - 1)
            {
                yield return this[point + 1];
            }
            if (start.Y < MaxY - 1)
            {
                if (start.Y % 2 != 0)
                {
                    if (start.X < MaxX - 1)
                    {
                        yield return this[point + MaxX + 1];
                    }
                }
                else
                {
                    if (start.X > 0)
                    {
                        yield return this[point + MaxX - 1];
                    }
                }
                yield return this[point + MaxX];
            }
        }

    }
}