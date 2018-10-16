/* $LAN=C#$ */
/*
	Name: Voronoi.cs
	Copyright: Copyright © 2016
	Author: 蘇王奕翔 I-Hsiang, Su Wang
    Student ID: M053040018
    Class: 資訊碩一
	Date: 03/11/16 11:56
	Description: The Voronoi structure
*/
using System.Collections.Generic;
using System.Drawing;

namespace VoronoiDiagram
{
    public class Voronoi
    {
        public List<PointF> pList; // 座標點集合
        public List<Edge> hpList;   // Hyper Plane 集合
        public List<Edge> vList;   // Voronoi 集合

        public Voronoi()
        {
            pList = new List<PointF>();
            vList = new List<Edge>();
            hpList = new List<Edge>();
        }
        public Voronoi(List<PointF> pList)
        {
            this.pList = pList;
            vList = new List<Edge>();
        }
        public Voronoi(List<PointF> pList, List<Edge> vList)
        {
            this.pList = pList;
            this.vList = vList;
        }

    }
}
