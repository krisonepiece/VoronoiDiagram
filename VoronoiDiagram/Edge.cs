/* $LAN=C#$ */
/*
	Name: Edge.cs
	Copyright: Copyright © 2016
	Author: 蘇王奕翔 I-Hsiang, Su Wang
    Student ID: M053040018
    Class: 資訊碩一
	Date: 03/11/16 11:56
	Description: The edge structure
*/
using System;
using System.Drawing;

namespace VoronoiDiagram
{
    public class Edge : Object
    {
        public PointF A;    // 線端點A座標
        public PointF B;    // 線端點B座標
        public PointF a;    // 做中垂線的點a座標
        public PointF b;    // 做中垂線的點b座標

        public Edge()
        {
        }
        public Edge(float x1, float y1, float x2, float y2)
        {
            this.A = new PointF(x1, y1);
            this.B = new PointF(x2, y2);
        }
        public Edge(PointF A, PointF B)
        {
            this.A = A;
            this.B = B;
        }
        public Edge(PointF A, PointF B, PointF a, PointF b)
        {
            this.A = A;
            this.B = B;
            this.a = a;
            this.b = b;
        }
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Edge e = obj as Edge;
            if (e == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (A.Equals(e.A) && B.Equals(e.B)) || (A.Equals(e.B) && B.Equals(e.A));
        }
        public bool Equals(Edge e)
        {
            // If parameter is null return false:
            if ((object)e == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (A.Equals(e.A) && B.Equals(e.B)) || (A.Equals(e.B) && B.Equals(e.A));
        }
        public override string ToString()
        {
            return "E " + A.X.ToString() + " " + A.Y.ToString() + " " + B.X.ToString() + " " + B.Y.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
