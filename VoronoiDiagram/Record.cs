/* $LAN=C#$ */
/*
	Name: Record.cs
	Copyright: Copyright © 2016
	Author: 蘇王奕翔 I-Hsiang, Su Wang
    Student ID: M053040018
    Class: 資訊碩一
	Date: 27/11/16 11:31
	Description: The Record structure
*/
using System;
using System.Collections.Generic;
using System.Drawing;

namespace VoronoiDiagram
{
    public class Record : Object
    {
        public List<PointF> pList;  // 點集合
        public List<Edge> eList;    // 線段集合
        public int type;            // 類型
        public bool clear;          // 是否需要清除之前的步驟
        public bool enable;         // 是否顯示
        public Record(List<PointF> pList, int type, bool clear = false)
        {
            this.pList = pList;
            this.type = type;
            this.clear = clear;
            this.enable = true;
        }
        public Record(List<Edge> eList, int type, bool clear = false)
        {

            this.eList = new List<Edge>();
            foreach (Edge i in eList)
                this.eList.Add(new Edge(i.A, i.B, i.a, i.b));
            this.type = type;
            this.clear = clear;
            this.enable = true;
        }
        public Record(Voronoi v, bool clear = false)
        {
            this.eList = v.vList;
            this.type = 1;
            this.clear = clear;
            this.enable = true;
        }
        public Record(List<PointF> pList, List<Edge> eList, int type, bool clear = false)
        {
            this.pList = pList;
            this.eList = eList;
            this.type = type;
            this.clear = clear;
            this.enable = true;
        }
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Record r = obj as Record;
            if (r == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (eList != null && eList.Count > 0)
            {
                for(int i = 0; i < eList.Count; i++)
                {
                    if (!r.eList[i].Equals(eList[i]))
                        return false;
                }
            }
            return type == r.type;
        }
        public bool Equals(Record r)
        {
            // If parameter is null return false:
            if ((object)r == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (eList != null && eList.Count > 0)
            {
                for (int i = 0; i < eList.Count; i++)
                {
                    if (!r.eList[i].Equals(eList[i]))
                        return false;
                }
            }
            return type == r.type;
        }
        public override string ToString()
        {
            string str = "";
            foreach(PointF i in pList)
            {
                str += "P " + i.X + " " + i.Y + "\r\n";
            }
            foreach (Edge i in eList)
            {
                str += i.ToString() + "\r\n";
            }

            return str;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
