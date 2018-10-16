/* $LAN=C#$ */
/*
	Name: MathEx.cs
	Copyright: Copyright © 2016
	Author: 蘇王奕翔 I-Hsiang, Su Wang
    Student ID: M053040018
    Class: 資訊碩一
	Date: 03/11/16 11:56
	Description: Custom math method
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VoronoiDiagram
{
    public static class MathEx
    {
        /// <summary>
        /// 計算三點之外心
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <param name="C">點C</param>
        /// <returns>外心座標</returns>
        public static PointF GetTriangleExcenterPointF(PointF A, PointF B, PointF C)
        {
            /* 共點 */
            if (A == B && A == C)
            {
                return A;
            }
            /* 以行列式計算外心，才不會有斜率為 0 或無限大的問題 */
            double x1 = A.X, x2 = B.X, x3 = C.X, y1 = A.Y, y2 = B.Y, y3 = C.Y;
            double c1 = (Math.Pow(x1, 2) + Math.Pow(y1, 2)) * (y2 - y3) + (Math.Pow(x2, 2) + Math.Pow(y2, 2)) * (y3 - y1) + (Math.Pow(x3, 2) + Math.Pow(y3, 2)) * (y1 - y2);
            double c2 = (Math.Pow(x1, 2) + Math.Pow(y1, 2)) * (x3 - x2) + (Math.Pow(x2, 2) + Math.Pow(y2, 2)) * (x1 - x3) + (Math.Pow(x3, 2) + Math.Pow(y3, 2)) * (x2 - x1);
            double c3 = ((y2 - y3) * x1 + (y3 - y1) * x2 + (y1 - y2) * x3) * 2;
            double x = c1 / c3;
            double y = c2 / c3;
            return new PointF(Convert.ToSingle(x), Convert.ToSingle(y));
        }

        /// <summary>
        /// 計算兩點之距離
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>兩點距離</returns>
        public static float GetLength(PointF A, PointF B)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2)));
        }
        public static PointF GetMidPointF(Edge e)
        {
            return GetMidPointF(e.A, e.B);
        }
        public static PointF GetMidPointF(PointF A, PointF B)
        {
            return new PointF((A.X + B.X) / 2, (A.Y + B.Y) / 2);
        }
        /// <summary>
        /// 向量OA叉積向量OB。大於零表示從OA到OB為順時針旋轉。
        /// </summary>
        /// <param name="O">點O</param>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>叉積</returns>
        public static float Cross(PointF O, PointF A, PointF B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }
        
        /// <summary>
        /// 取得 A 到 B 的向量
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>A 到B 的向量</returns>
        public static PointF GetVectorAB(PointF A, PointF B)
        {
            return new PointF(B.X - A.X, B.Y - A.Y);
        }

        /// <summary>
        /// 兩點距離的平方
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>兩點距離平方</returns>
        public static float GetDistance(PointF A, PointF B)
        {
            return (A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y);
        }

        /// <summary>
        /// 找距離遠的點
        /// </summary>
        /// <param name="O">點O</param>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>OA 是否比 OB 遠</returns>
        public static bool isFar(PointF O, PointF A, PointF B)
        {
            return GetDistance(O, A) > GetDistance(O, B);
        }
        /// <summary>
        /// 找距離近的點
        /// </summary>
        /// <param name="O">點O</param>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>OA 是否比 OB 近</returns>
        public static bool isNear(PointF O, PointF A, PointF B)
        {
            return GetDistance(O, A) < GetDistance(O, B);
        } 
        /// <summary>
        /// 計算重心
        /// </summary>
        /// <param name="pList">座標點</param>
        /// <returns>重心座標</returns>
        public static PointF GetCenterPointF(List<PointF> pList)
        {
            float X = 0;
            float Y = 0;
            for(int i = 0; i < pList.Count; i++)
            {
                X += pList[i].X;
                Y += pList[i].Y;
            }
            return new PointF(X / pList.Count, Y / pList.Count);
        }
        /// <summary>
        /// 依 lexical order 排序點
        /// </summary>
        /// <param name="pList">點集合</param>
        /// <returns>排序後的點</returns>
        public static List<PointF> SortPointF(List<PointF> pList)
        {
            pList = pList.OrderBy(A => A.X).ThenBy(B => B.Y).ToList();
            return pList;
        }
        /// <summary>
        /// 依 lexical order 排序邊
        /// </summary>
        /// <param name="eList">邊集合</param>
        /// <returns>排序後的邊</returns>
        public static List<Edge> SortEdge(List<Edge> eList)
        {
            /* 線兩端點排序 */
            for (int i = 0; i < eList.Count; i++)
            {
                if (eList[i].A.X > eList[i].B.X || (eList[i].A.X == eList[i].B.X && eList[i].A.Y > eList[i].B.Y))
                {
                    PointF tmpP = new PointF();
                    tmpP = eList[i].A;
                    eList[i].A = eList[i].B;
                    eList[i].B = tmpP;
                }
            }
            /* 線之間排序 */
            eList = eList.OrderBy(x => x.A.X).ThenBy(y => y.B.X).ToList();
            return eList;
        }
        /// <summary>
        /// 依逆時針方向排序點
        /// </summary>
        /// <param name="pList">座標點</param>
        /// <returns>排序後的座標點</returns>
        public static List<PointF> SortVector(List<PointF> pList)
        {
            PointF center = GetCenterPointF(pList);

            for (int i = 0; i < pList.Count - 1; i++)
            {
                for(int j = 0; j < pList.Count - i - 1; j++)
                {
                    if(Cross(center, pList[j], pList[j + 1]) > 0)
                    {
                        PointF tmpP = new PointF();
                        tmpP = pList[j + 1];
                        pList[j + 1] = pList[j];
                        pList[j] = tmpP;
                    }
                }
            }
            return pList;
        }
        /// <summary>
        /// 計算法向量
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>法向量</returns>
        public static PointF GetNormalVector(PointF A, PointF B)
        {           
            PointF vectorAB = GetVectorAB(A, B);

            /* 將AB向量，顛倒、變號，得到法向量 */
            float tmp = vectorAB.X;
            vectorAB.X = vectorAB.Y;
            vectorAB.Y = tmp;
            vectorAB.X *= -1;

            return vectorAB;
        }
        /// <summary>
        /// 取得中垂線
        /// </summary>
        /// <param name="e">線</param>
        /// <returns>中垂線</returns>
        public static Edge GetBisector(this Edge e)
        {
            PointF mid = MathEx.GetMidPointF(e.A, e.B);
            return new Edge(mid.Add(GetNormalVector(e.A, e.B).Multi(600)), mid.Add(GetNormalVector(e.B, e.A).Multi(600)), e.A, e.B);
        }
        /// <summary>
        /// 向量相加
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>相加後的向量</returns>
        public static PointF Add(this PointF A, PointF B)
        {
            return new PointF(A.X + B.X, A.Y + B.Y);
        }
        /// <summary>
        /// 向量延伸
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="multi">倍率</param>
        /// <returns>延伸後的向量</returns>
        public static PointF Multi(this PointF A, float multi)
        {
            return new PointF(A.X * multi, A.Y * multi);
        }
        /// <summary>
        /// 判斷三點共線
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns>是否共線</returns>
        public static bool isCollinear(PointF A, PointF B, PointF C)
        {
            return (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) == 0 ? true: false;
        }
        /// <summary>
        /// 切割點集合
        /// </summary>
        /// <param name="pList">點集合</param>
        /// <param name="pListL">切割後的左半部</param>
        /// <param name="pListR">切割後的右半部</param>
        public static void Divide(List<PointF> pList, out List<PointF> pListL, out List<PointF> pListR)
        {
            pListL = new List<PointF>();
            pListR = new List<PointF>();

            for (int i = 0; i < pList.Count; i++)
            {
                if (i < ((pList.Count % 2 == 1) ? (pList.Count + 1) / 2 : pList.Count / 2))
                    pListL.Add(pList[i]);
                else
                    pListR.Add(pList[i]);
            }
        }
        /// <summary>
        /// 計算 Convex Hull (Jarvis' March) 
        /// </summary>
        /// <param name="pList">點集合</param>
        /// <returns>Convex Hull</returns>
        public static List<PointF> GetConvexHull(List<PointF> pList)
        {            
            List<int> chList = new List<int>();     // Convex Hull 索引
            List<int> visited = new List<int>();    // 待走訪的點，確認下一個 Convex Hull 點後，把該點從 List 移除
            bool isAllCollinear = true;             // 是否全部共線，若全部共線，全部點走訪完後須回頭走訪一次
            bool hasbetter = false;                 // 是否有更好的點
            int tmp = 0;

            /* 起點必須是凸包上的頂點。 */
            int start = 0;

            /* 包禮物，逆時針方向。 */
            int m = 0;                  // 凸包頂點數目
            chList.Add(start);          // 紀錄起點

            /* 加入待走訪的點 */
            for (int i = 0; i < pList.Count; i++)
                visited.Add(i);

            /* 預設下一個走訪點 */
            int next = visited[1];

            for (m = 1; true; m++)
            {
                hasbetter = false;
                /* 找出位於最外圍的一點，若凸包上有多點共線則找最遠的一點。 */
                foreach (int i in visited)
                {
                    tmp = next;
                    /* 若走訪點為當前比較向量的兩端點則走訪下一個點 */
                    if (i == next || i == chList[m - 1])
                    {
                        continue;
                    }
                    float c = Cross(pList[chList[m - 1]], pList[i], pList[next]);
                    /* 有逆時針旋轉 */
                    if (c < 0)
                    {
                        next = i;
                        isAllCollinear = false;
                        hasbetter = true;
                    }
                    /* 共線時，找最近的點，並且不能找回原點 */
                    else if (c == 0 && isNear(pList[chList[m - 1]], pList[i], pList[next]) && i != visited[0])
                    {
                        tmp = i;
                    }
                    else if (c > 0)
                    {
                        isAllCollinear = false;
                    }

                }
                /* 沒更好的答案，則取共線點 */
                if (!hasbetter)
                    next = tmp;

                /* 繞一圈後回到起點 */
                if (next == start)
                    break;

                chList.Add(next);       // 紀錄方才所找到的點
                visited.Remove(next);   // 移除走訪過的點

                /* 決定下個走訪的點 */
                if (visited.Count > 1)
                    next = visited[1];
                else
                    next = visited[0];
            }
            /* 若全部共線則往回走到起點前 */
            if (isAllCollinear)
            {
                for (int i = chList.Count - 2; i > 0; i--)
                {
                    chList.Add(chList[i]);
                }
            }

            List<PointF> convexHull = new List<PointF>();
            foreach(int i in chList)
            {
                convexHull.Add(pList[i]);
            }
            return convexHull;
        }
        /// <summary>
        /// 叉積運算，回傳純量（除去方向）
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>叉積(無方向)</returns>
        public static float Cross(PointF A, PointF B)
        {
            return A.X * B.Y - A.Y * B.X;
        }
        public static PointF? GetIntersection(Edge e1, Edge e2)
        {
            return GetIntersection(e1.A, e1.B, e2.A, e2.B);
        }
        public static PointF? GetIntersection(PointF a1, PointF a2, PointF b1, PointF b2)
        {
            PointF a = GetVectorAB(a1, a2), b = GetVectorAB(b1, b2), s = GetVectorAB(a1, b1);
            float c1 = Cross(a, b);
            float c2 = Cross(s, b);
            float c4 = Cross(s, a);    // c4方向顛倒

            if (c1 < 0)
            {
                c1 = -c1;
                c2 = -c2;
                c4 = -c4;
            }
            if (c1 != 0 && c2 >= 0 && c2 <= c1 && c4 >= 0 && c4 <= c1)
                return a1.Add(a.Multi( ((float)((decimal)c2 / (decimal)c1)) ) );
            else
                return null;
        }
        public static bool RangeEqual(float A, float B, float range = 0.001F)
        {
            if (A - B < range)
                return true;
            return false;
        } 
    }
}
