using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon
{
    /// <summary>
    /// マップデータ
    /// </summary>
    public class Map :IEnumerable
    {
        /// <summary> 最大X座標 </summary>
        public int MaxX { get; }
        /// <summary> 最大Y座標 </summary>
        public int MaxY { get; }

        /// <summary> 全座標データ </summary>
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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                yield return this[i];
            }
        }
        /// <summary>
        /// 座標データを生成する
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
        /// <summary>
        /// 指定座標から周囲6方向の座標データ返す
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        IEnumerable<Point> GetNeighorPoints(int point)
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