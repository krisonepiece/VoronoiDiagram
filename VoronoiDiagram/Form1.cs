/* $LAN=C#$ */
/*
	Name: Form1.cs
	Copyright: Copyright © 2016
	Author: 蘇王奕翔 I-Hsiang, Su Wang
    Student ID: M053040018
    Class: 資訊碩一
	Date: 03/11/16 11:56
	Description: Controls events and GUI
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VoronoiDiagram
{
    public partial class main_form : Form
    {
        /* Record type */
        private const int VORONOI = 1;
        private const int CONVEX_HULL = 2;
        private const int TANGENT = 3;
        private const int HYPER_LINE = 4;
        private const int MERGE = 5;

        List<PointF> pList = new List<PointF>();    // 輸入的點集合
        List<Record> record = new List<Record>();   // 紀錄
        Voronoi v = new Voronoi();                  // 最終的 Voronoi Diagram
        int stepIndex = 0;                          // 目前執行到的步驟數
        Thread t;
        Bitmap b;
        public main_form()
        {
            InitializeComponent();
        }

        #region 控制項事件                

        #region 畫點
        private void paint_pic_MouseClick(object sender, MouseEventArgs e)
        {
            PointF p = new PointF(e.X, e.Y);
            AddPointF(p);
        }
        #endregion

        #region 執行
        private void run_btn_Click(object sender, EventArgs e)
        {
            Run();
        }
        private void run_mitem_Click(object sender, EventArgs e)
        {
            Run();
        }
        private void Run()
        {
            if(pList.Count > 0)
            {
                /* 初始化 */
                v.pList.Clear();
                v.vList.Clear();
                record.Clear();
                stepIndex = 0;
                ClearPaint();

                /* 初始畫布建置 */
                ClearPaint();
                foreach (PointF i in pList)
                {
                    DrawPointF(i, Color.DarkRed);
                }

                /* 排序點 */
                pList = MathEx.SortPointF(pList);

                /* 畫 Convex Hull */
                DrawConvexHull(MathEx.GetConvexHull(pList));

                /* 畫 Voronoi Diagram */
                v = VoronoiMultiPoint(pList);
                DrawVoronoiDiagram(v.vList, Color.DarkGreen);
            }
        }
        #endregion

        #region Step By Step        
        private void step_btn_Click(object sender, EventArgs e)
        {            
            Step();
        }
        private void step_mitem_Click(object sender, EventArgs e)
        {
            Step();
        }
        private void Step()
        {
            if(record.Count <= 0 || stepIndex > record.Count - 1)
            {
                /* 初始化 */
                v.pList.Clear();
                v.vList.Clear();
                record.Clear();
                stepIndex = 0;

                /* 排序點 */
                pList = MathEx.SortPointF(pList);

                /* 畫 Voronoi Diagram */
                v = VoronoiMultiPoint(pList);
            }

            /* 初始畫布建置 */
            ClearPaint();
            foreach (PointF i in pList)
            {
                DrawPointF(i, Color.DarkRed);
            }

            /* 隱藏特定紀錄 */
            if (record[stepIndex].type == VORONOI)
            {
                if (record[stepIndex].clear)
                {
                    record[stepIndex - 2].enable = false;
                    int count = 0;
                    for(int i = stepIndex - 1; i >= 0 && count < 2; i--)
                    {
                        if((record[i].type == MERGE || record[i].type == VORONOI) && record[i].enable == true)
                        {
                            record[i].enable = false;
                            count++;
                        }
                    }
                }
            }
            else if (record[stepIndex].type == CONVEX_HULL)
            {
                if (record[stepIndex].clear)
                {
                    record[stepIndex - 1].enable = false;
                    record[stepIndex - 2].enable = false;
                }
            }
            else if (record[stepIndex].type == MERGE)
            {
                if (record[stepIndex].clear)
                {
                    record[stepIndex - 1].enable = false;
                    record[stepIndex - 2].enable = false;
                }
            }

            /* 畫紀錄 */
            for (int i = 0; i <= stepIndex; i++)
            {
                if (record[i].enable)
                    DrawRecord(record[i]);
                else
                    continue;
            }

            /* 重置步驟數 */
            if (stepIndex < record.Count)
                stepIndex++;
            else
                stepIndex = 0;
        }
        private void DrawRecord(Record r)
        {
            if (r.type == VORONOI)
            {
                Color color = new Color();
                if (r.clear == true) {
                    color = Color.DarkGreen;
                }
                else
                {
                    int index = record.IndexOf(r);
                    switch (index % 2)
                    {
                        case 0: color = Color.DodgerBlue; break;
                        case 1: color = Color.Firebrick; break;
                    }
                }                
                DrawVoronoiDiagram(r.eList, color);
            }
            else if (r.type == CONVEX_HULL)
            {
                DrawConvexHull(r.pList, r.eList);
            }
            else if (r.type == HYPER_LINE)
            {
                foreach (Edge i in r.eList)
                    DrawLine(i, Color.Blue);
            }
            else if (r.type == MERGE)
            {
                foreach (Edge i in r.eList)
                    DrawLine(i, Color.DarkGreen);
            }
        }
        #endregion

        #region 清除
        private void clear_btn_Click(object sender, EventArgs e)
        {
            Init();
            ClearPaint();
        }
        private void clear_mitem_Click(object sender, EventArgs e)
        {
            Init();
            ClearPaint();
        }
        #region 清除點
        private void ClearPointF()
        {
            pList.Clear();
            node_lbx.Items.Clear();
        }
        #endregion

        #region 清除畫布
        private void ClearPaint()
        {
            Graphics g = Graphics.FromImage(b);            
            g.Clear(paint_pic.BackColor);
            paint_pic.Image = b;
        }
        #endregion

        #region 初始化資料
        private void Init()
        {
            v.pList.Clear();
            v.vList.Clear();
            ClearPointF();
            record.Clear();
            stepIndex = 0;
        }
        #endregion

        #endregion

        #region 新增座標點
        private void add_btn_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;

            if (Int32.TryParse(x_txt.Text, out x) && Int32.TryParse(y_txt.Text, out y))
            {
                PointF p = new PointF(Convert.ToSingle(x_txt.Text), Convert.ToSingle(y_txt.Text));
                AddPointF(p);
            }
            else
            {
                MessageBox.Show("Please enter the correct coordinates！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 隨機產生亂數點
        private void random_btn_Click(object sender, EventArgs e)
        {
            int amount = 0;
            if (Int32.TryParse(amount_txt.Text, out amount))
            {  
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                /* 初始化 */
                Init();
                ClearPaint();

                for (int i = 0; i < amount; i++)
                {
                    PointF p = new PointF(rnd.Next(paint_pic.Width), rnd.Next(paint_pic.Height));
                    AddPointF(p);
                }
            }
            else
            {
                MessageBox.Show("Please enter the number！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region 輸入檔案
        private void open_btn_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void open_mitem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        #region 開啟
        private void OpenFile()
        {
            /* 初始化 */
            Init();
            ClearPaint();
            if (t != null)
                Stop();

            /* 選擇檔案 */
            open_fdg.Title = "Open";
            if (open_fdg.ShowDialog() == DialogResult.OK)
            {
                /* 建立可傳遞參數的執行緒 */
                ParameterizedThreadStart parT = new ParameterizedThreadStart(Read);
                t = new Thread(parT);
                t.Start(open_fdg.FileName);
            }
        }
        #endregion

        #region 讀檔
        /* 宣告委派的方法 */
        public delegate void AddPointFInvoke(PointF p);
        public delegate void AddvEdgeInvoke(Edge e);
        /* 宣告執行緒狀態的信號 */
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        public void Read(object o)
        {
            /* 因 AddPointF 方法中，有更新到 UI 介面，故需以此種方式委派 */
            AddPointFInvoke api = new AddPointFInvoke(AddPointF);
            AddvEdgeInvoke aei = new AddvEdgeInvoke(AddvEdge);
            string fileName = o as string;
            string line;

            /* 建立資料流 */
            StreamReader file = new StreamReader(fileName, Encoding.Default);

            while ((line = file.ReadLine()) != null)
            {
                
                if (!line.Equals(""))
                {
                    /* 讀取輸出的文字檔案: 繪製點 */
                    if (line[0].Equals('P'))
                    {
                        string[] coord = line.Split(' ');
                        PointF p = new PointF(Convert.ToSingle(coord[1]), Convert.ToSingle(coord[2]));
                        Invoke(api, new object[] { p });
                    }
                    /* 讀取輸出的文字檔案: 繪製邊 */
                    else if (line[0].Equals('E'))
                    {
                        string[] coord = line.Split(' ');                        
                        Edge e = new Edge(Convert.ToSingle(coord[1]), Convert.ToSingle(coord[2]), Convert.ToSingle(coord[3]), Convert.ToSingle(coord[4]));
                        Invoke(aei, new object[] { e });
                    }
                    /* 讀到 0 停止 */
                    else if (line.Equals("0"))
                    {
                        MessageBox.Show("read finish！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Stop();
                        v.pList.Clear();
                        v.vList.Clear();
                        break;
                    }
                    /* 略過 # 註解符號 */
                    else if (!line[0].Equals('#'))
                    {
                        string innerLine;
                        for (int i = 0; i < Convert.ToInt32(line); i++)
                        {
                            innerLine = file.ReadLine();
                            string[] coord = innerLine.Split(' ');
                            PointF p = new PointF(Convert.ToSingle(coord[0]), Convert.ToSingle(coord[1]));
                            Invoke(api, new object[] { p });
                        }
                        /* 封鎖目前執行緒，直到waitHandle收到通知，Timeout.Infinite表示無限期等候 */
                        Pause();
                        _pauseEvent.WaitOne(Timeout.Infinite);
                    }
                }
                else
                    continue;
            }
            /* 關閉資料流 */
            file.Close();
        }
        public void Pause()
        {
            /* 將暫停信號設為收不到訊號 */
            _pauseEvent.Reset();
        }
        public void Resume()
        {
            /* 將暫停信號設為收到訊號 */
            _pauseEvent.Set();
        }
        public void Stop()
        {
            /* 將結束信號設為收到信號 */
            _shutdownEvent.Set();

            /* 關閉執行緒 */
            _pauseEvent.Set();
            t.Abort();
            t.Join();
        }
        #endregion

        #endregion

        #region 讀下一筆資料
        private void next_btn_Click(object sender, EventArgs e)
        {
            Init();
            ClearPaint();
            Resume();
        }
        #endregion

        #region 輸出檔案
        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        private void save_mitem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        #region 儲存檔案
        private void SaveFile()
        {
            //if(v.vList != null && v.vList.Count > 0)
            //{
                /* 依 lexical order 排序 */
                v.pList = MathEx.SortPointF(v.pList);
                v.vList = MathEx.SortEdge(v.vList);

                save_fdg.Title = "Save";
                if (save_fdg.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(save_fdg.FileName);
                    for (int i = 0; i < v.pList.Count; i++)
                    {
                        sw.WriteLine("P " + v.pList[i].X + " " + v.pList[i].Y);
                    }
                    for (int i = 0; i < v.vList.Count; i++)
                    {
                        sw.WriteLine("E " + Convert.ToInt32(v.vList[i].A.X) + " " + Convert.ToInt32(v.vList[i].A.Y) + " "
                            + Convert.ToInt32(v.vList[i].B.X) + " " + Convert.ToInt32(v.vList[i].B.Y));
                    }
                    sw.Close();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Please draw some diagram！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            
        }
        #endregion

        #endregion

        #region 滑鼠移動資訊
        private void paint_pic_MouseMove(object sender, MouseEventArgs e)
        {
            info_statuslbl.Text = "(" + e.X.ToString() + ", " + e.Y.ToString() + ")";
        }
        #endregion        

        #region 關閉
        private void main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null)
            {
                t.Abort();
            }
        }
        private void exit_mitem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion        

        #region 新增點
        private void AddPointF(PointF p)
        {
            pList.Add(p);
            node_lbx.Items.Add("(" + p.X + ", " + p.Y + ")");
            DrawPointF(p, Color.DarkRed);
        }
        #endregion                

        #region 新增邊
        private void AddvEdge(Edge e)
        {
            v.vList.Add(e);
            DrawLine(e, Color.DarkGreen);
        }
        #endregion

        #region 載入Form
        private void main_form_Load(object sender, EventArgs e)
        {
            b = new Bitmap(paint_pic.Width, paint_pic.Height);
        }
        #endregion

        #region 重繪
        private void main_form_Paint(object sender, PaintEventArgs e)
        {
            paint_pic.Image = b;
        }
        #endregion        

        #region 關於
        private void about_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voronoi Diagram\nCopyright © 2016 I-Hsiang, Su Wang", "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        #endregion

        #endregion

        #region 作圖
        /// <summary>
        /// 畫線
        /// </summary>
        /// <param name="e">邊</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawLine(Edge e, Color color)
        {
            DrawLine(e.A, e.B, color);
        }
        /// <summary>
        /// 畫線
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawLine(PointF A, PointF B, Color color)
        {
            Graphics g = Graphics.FromImage(b);
            Pen pen = new Pen(color);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(pen, A, B);
            paint_pic.Image = b;
        }
        /// <summary>
        /// 畫點
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawPointF(PointF A, Color color)
        {
            DrawPointF(A.X, A.Y, color);
        }
        /// <summary>
        /// 畫點
        /// </summary>
        /// <param name="X">座標X</param>
        /// <param name="Y">座標Y</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawPointF(float X, float Y, Color color)
        {
            Graphics g = Graphics.FromImage(b);
            Brush brush = new SolidBrush(color);
            RectangleF r = new RectangleF(X - 2, Y - 2, 5, 5);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillEllipse(brush, r);
            paint_pic.Image = b;
        }
        /// <summary>
        /// 畫 Voronoi Diagram
        /// </summary>
        /// <param name="v">Voronoi 物件</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawVoronoiDiagram(Voronoi v, Color color)
        {
            DrawVoronoiDiagram(v.vList, color);
        }
        /// <summary>
        /// 畫 Voronoi Diagram
        /// </summary>
        /// <param name="e">Voronoi Edge</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawVoronoiDiagram(List<Edge> e, Color color)
        {
            for (int i = 0; i < e.Count; i++)
            {
                if (e[i].A.Equals(e[i].B))
                {
                    e.RemoveAt(i);
                    i--;
                    continue;
                }
                DrawLine(e[i], color);
            }
        }
        /// <summary>
        /// 畫文字
        /// </summary>
        /// <param name="str">文字</param>
        /// <param name="X">座標X</param>
        /// <param name="Y">座標Y</param>
        /// <param name="color">畫筆顏色</param>
        public void DrawString(string str, float X, float Y, Color color)
        {
            Graphics g = Graphics.FromImage(b);
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(color);
            PointF drawPoint = new PointF(X, Y);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawString(str, drawFont, drawBrush, drawPoint);
            paint_pic.Image = b;
        }
        /// <summary>
        /// 畫 Convex Hull
        /// </summary>
        /// <param name="pList">點集合</param>
        public void DrawConvexHull(List<PointF> pList, List<Edge> tangent = null)
        {
            bool isTangent;
            for (int i = 0; i < pList.Count; i++)
            {
                isTangent = false;
                if (tangent != null)
                {
                    foreach (Edge j in tangent)
                    {
                        if (j.Equals(new Edge(pList[i], pList[(i + 1) % pList.Count])))
                        {
                            isTangent = true;
                            break;
                        }
                    }
                }
                if (isTangent)
                    DrawLine(pList[i], pList[(i + 1) % pList.Count], Color.LightPink);
                else
                    DrawLine(pList[i], pList[(i + 1) % pList.Count], Color.LightBlue);

                DrawString(i.ToString(), pList[i].X - 5, pList[i].Y + 3, Color.Black);
            }
        }        
        #endregion

        #region Voronoi Functions

        #region 計算兩個點的Voronoi Diagram
        /// <summary>
        /// 計算兩個點的Voronoi Diagram
        /// </summary>
        /// <returns>Voronoi Diagram</returns>
        public Voronoi VoronoiTwoPoint(List<PointF> pList)
        {
            return VoronoiTwoPoint(pList[0], pList[1]);
        }
        public Voronoi VoronoiTwoPoint(PointF A, PointF B)
        {
            PointF mid = MathEx.GetMidPointF(A, B);
            Voronoi v = new Voronoi();

            v.pList.Add(A);
            v.pList.Add(B);
            /* 將邊無限延伸的做法 */
            v.vList.Add(new Edge(mid.Add(MathEx.GetNormalVector(A, B).Multi(600)), mid.Add(MathEx.GetNormalVector(B, A).Multi(600)), A, B));
            
            /* 將邊畫到邊界的做法
             * v.vList.Add(new Edge(GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(A, B))), GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(B, A)))));
             */
            return v;
        }
        #endregion

        #region 計算三個點的Voronoi Diagram
        /// <summary>
        /// 計算三個點的Voronoi Diagram
        /// </summary>
        /// <returns>Voronoi Diagram</returns>
        public Voronoi VoronoiThreePoint(List<PointF> pList)
        {
            return VoronoiThreePoint(pList[0], pList[1], pList[2]);
        }
        public Voronoi VoronoiThreePoint(PointF A, PointF B, PointF C)
        {
            Voronoi v = new Voronoi();
            PointF triEx;
            PointF mid;

            v.pList.Add(A);
            v.pList.Add(B);
            v.pList.Add(C);

            /* 三點共線 */
            if (MathEx.isCollinear(v.pList[0], v.pList[1], v.pList[2]))
            {
                /* 將點排序 */
                v.pList = MathEx.SortPointF(v.pList);                

                /* 將邊無限延伸的做法 */
                mid = MathEx.GetMidPointF(v.pList[0], v.pList[1]);
                v.vList.Add(new Edge(mid.Add(MathEx.GetNormalVector(v.pList[0], v.pList[1]).Multi(600)), mid.Add(MathEx.GetNormalVector(v.pList[1], v.pList[0]).Multi(600)), v.pList[0], v.pList[1]));
                mid = MathEx.GetMidPointF(v.pList[1], v.pList[2]);
                v.vList.Add(new Edge(mid.Add(MathEx.GetNormalVector(v.pList[1], v.pList[2]).Multi(600)), mid.Add(MathEx.GetNormalVector(v.pList[2], v.pList[1]).Multi(600)), v.pList[1], v.pList[2]));

                /* 將邊畫到邊界的做法
                 * mid = MathEx.GetMidPointF(v.pList[0], v.pList[1]);
                 * v.vList.Add(new Edge(GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(v.pList[1], v.pList[0]))), GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(v.pList[0], v.pList[1])))));
                 * mid = MathEx.GetMidPointF(v.pList[1], v.pList[2]);
                 * v.vList.Add(new Edge(GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(v.pList[2], v.pList[1]))), GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(v.pList[1], v.pList[2])))));
                 */
            }
            else
            {
                /* 計算外心 */
                triEx = MathEx.GetTriangleExcenterPointF(A, B, C);

                /* 將點依逆時針方向排序 */
                v.pList = MathEx.SortVector(v.pList);

                for (int i = 0; i < v.pList.Count; i++)
                {
                    mid = MathEx.GetMidPointF(v.pList[i], v.pList[(i + 1) % 3]);

                    /* 將邊無限延伸的做法 */
                    v.vList.Add(new Edge(triEx, mid.Add(MathEx.GetNormalVector(v.pList[i], v.pList[(i + 1) % 3]).Multi(600)), v.pList[i], v.pList[(i + 1) % 3]));
                    
                    /* 將邊畫到邊界的做法
                     * v.vList.Add(new Edge(triEx, GetSidePointF(mid, mid.Add(MathEx.GetNormalVector(v.pList[i], v.pList[(i + 1) % 3])))));
                     */
                }
            }
            return v;
        }
        #endregion

        #region 計算多個點的Voronoi Diagram
        /// <summary>
        /// 計算多個點的Voronoi Diagram
        /// </summary>
        /// <returns>Voronoi Diagram</returns>
        public Voronoi VoronoiMultiPoint(List<PointF> pList)
        {
            Voronoi v = new Voronoi();

            if (pList.Count == 1)
                return v;
            else if (pList.Count == 2)
            {
                Voronoi twoVoronoi = VoronoiTwoPoint(pList);
                record.Add(new Record(twoVoronoi.vList, VORONOI));
                return twoVoronoi;
            }
            else if (pList.Count == 3)
            {
                Voronoi threeVoronoi = VoronoiThreePoint(pList);
                record.Add(new Record(threeVoronoi.vList, VORONOI));
                return threeVoronoi;
            }                
            else if(pList.Count > 3)
            {
                List<PointF> pListL;
                List<PointF> pListR;
                MathEx.Divide(pList, out pListL, out pListR);
                v = Merge(VoronoiMultiPoint(pListL), VoronoiMultiPoint(pListR));
            }
            return v;
        }
        /// <summary>
        /// 合併左右半部的 Voronoi Diagram
        /// </summary>
        /// <param name="vL">左半部的 Voronoi Diagram</param>
        /// <param name="vR">右半部的 Voronoi Diagram</param>
        /// <returns>合併的 Voronoi Diagram</returns>
        public Voronoi Merge(Voronoi vL, Voronoi vR)
        {
            Voronoi v = new Voronoi();
            try
            {
                /* 找上切線和下切線 */
                List<PointF> chL = MathEx.GetConvexHull(vL.pList);
                record.Add(new Record(chL, CONVEX_HULL));
                List<PointF> chR = MathEx.GetConvexHull(vR.pList);
                record.Add(new Record(chR, CONVEX_HULL));
                List<Edge> tangent = GetTangent(chL, chR);

                #region 找 Hyper Plane
                List<Edge> hpList = new List<Edge>();   // Hyper Plane
                PointF? p;                              // 暫存 Hyper Plane 與 Voronoi 的交點
                PointF? nearPoint = null;               // Hyper Plane 與 Voronoi 最先碰到的交點
                PointF? lastNearPoint = null;           // 上一個 nearPoint
                Edge scan;                              // 掃描線段
                Edge candidate = new Edge();            // 碰到的線段
                Edge last = new Edge();                 // 上一個碰到的線段
                Edge hyperPlane = new Edge();           // 當前的 Hyper Plane
                List<int> eliminate = new List<int>();  // 需要消線的索引
                List<int> delete = new List<int>();     // 需要刪線的索引

                foreach (PointF i in vL.pList)
                    v.pList.Add(new PointF(i.X, i.Y));
                foreach (PointF i in vR.pList)
                    v.pList.Add(new PointF(i.X, i.Y));
                foreach (Edge i in vL.vList)
                    v.vList.Add(new Edge(i.A, i.B, i.a, i.b));
                foreach (Edge i in vR.vList)
                    v.vList.Add(new Edge(i.A, i.B, i.a, i.b));

                /* 掃描線從上切線進入 */
                scan = new Edge(tangent[0].A, tangent[0].B);
                lastNearPoint = scan.GetBisector().A;
                while (!scan.Equals(tangent[1]))
                {
                    hyperPlane = scan.GetBisector();                

                    /* 找最先碰到的線的交點 */
                    nearPoint = null;
                    for (int i = 0; i < v.vList.Count; i++)
                    {                    
                        if (last != null && last.Equals(v.vList[i]))
                            continue;
                        /* 找交點且 Hyper Plane 不能回頭 */
                        if ((p = MathEx.GetIntersection(hyperPlane, v.vList[i])) != null && Math.Round(Convert.ToDouble(((PointF)lastNearPoint).Y)) >= ((PointF)p).Y)
                        {
                            /* 找到第一個交點 */
                            if (nearPoint == null)
                            {
                                nearPoint = p;
                                candidate = v.vList[i];
                                continue;
                            }
                            if (MathEx.GetDistance(hyperPlane.A, (PointF)p) < MathEx.GetDistance(hyperPlane.A, (PointF)nearPoint))
                            {
                                nearPoint = p;
                                candidate = v.vList[i];
                            }
                        }
                    }
                
                    /* 從上一段 Hyper Plane 接著畫 */
                    if (lastNearPoint != null)
                        hyperPlane.A = (PointF)lastNearPoint;
                    hpList.Add(new Edge(hyperPlane.A, (PointF)nearPoint, scan.A, scan.B));

                    eliminate.Add(v.vList.IndexOf(candidate));
                    last = candidate;
                    lastNearPoint = nearPoint;                 

                    /* 尋找下一條掃描線 */
                    if (scan.A.Equals(candidate.a))
                        scan.A = candidate.b;
                    else if (scan.A.Equals(candidate.b))
                        scan.A = candidate.a;
                    else if (scan.B.Equals(candidate.a))
                        scan.B = candidate.b;
                    else if (scan.B.Equals(candidate.b))
                        scan.B = candidate.a;
                }
                /* 上切線等於下切線：共線 */
                if (tangent[0].Equals(tangent[1]))
                    hpList.Add(new Edge(tangent[0].GetBisector().A, tangent[0].GetBisector().B, scan.A, scan.B));
                else
                    hpList.Add(new Edge((PointF)nearPoint, tangent[1].GetBisector().A, scan.A, scan.B));
            
                record.Add(new Record(hpList, HYPER_LINE));
                #endregion

                #region 消線
                for(int i = 0; i < eliminate.Count; i++)
                {
                    if(MathEx.Cross(hpList[i].A, hpList[i].B, hpList[i + 1].B) >= 0)
                    {
                        if(MathEx.Cross(hpList[i].A, hpList[i].B, v.vList[eliminate[i]].A) > 0)
                        {                        
                            /* 消除延伸線 */
                            foreach (Edge j in v.vList)
                            {
                                if (j.A.Equals(v.vList[eliminate[i]].A) && !j.B.Equals(v.vList[eliminate[i]].B))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.A, j.B) > 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                                else if (j.B.Equals(v.vList[eliminate[i]].A) && !j.A.Equals(v.vList[eliminate[i]].B))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.B, j.A) > 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                            }
                            v.vList[eliminate[i]].A = hpList[i].B;
                        }
                        else
                        {
                            /* 消除延伸線 */
                            foreach (Edge j in v.vList)
                            {
                                if (j.A.Equals(v.vList[eliminate[i]].B) && !j.B.Equals(v.vList[eliminate[i]].A))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.A, j.B) > 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                                else if (j.B.Equals(v.vList[eliminate[i]].B) && !j.A.Equals(v.vList[eliminate[i]].A))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.B, j.A) > 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                            }
                            v.vList[eliminate[i]].B = hpList[i].B;
                        }                        
                    }
                    else if (MathEx.Cross(hpList[i].A, hpList[i].B, hpList[i + 1].B) < 0)
                    {
                        if (MathEx.Cross(hpList[i].A, hpList[i].B, v.vList[eliminate[i]].A) < 0)
                        {                        
                            /* 消除延伸線 */
                            foreach (Edge j in v.vList)
                            {
                                if (j.A.Equals(v.vList[eliminate[i]].A) && !j.B.Equals(v.vList[eliminate[i]].B))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.A, j.B) < 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                                else if (j.B.Equals(v.vList[eliminate[i]].A) && !j.A.Equals(v.vList[eliminate[i]].B))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.B, j.A) < 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                            }
                            v.vList[eliminate[i]].A = hpList[i].B;
                        }
                        else
                        {                        
                            /* 消除延伸線 */
                            foreach (Edge j in v.vList)
                            {
                                if (j.A.Equals(v.vList[eliminate[i]].B) && !j.B.Equals(v.vList[eliminate[i]].A))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.A, j.B) < 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                                else if (j.B.Equals(v.vList[eliminate[i]].B) && !j.A.Equals(v.vList[eliminate[i]].A))
                                {
                                    if (MathEx.Cross(hpList[i].B, j.B, j.A) < 0)
                                    {
                                        delete.Add(v.vList.IndexOf(j));
                                    }
                                }
                            }
                            v.vList[eliminate[i]].B = hpList[i].B;
                        }                    
                    }
                }
                /* 刪除延伸線 */
                delete = delete.OrderByDescending(X => X).Distinct().ToList();
                foreach(int i in delete)
                    v.vList.RemoveAt(i);

                record.Add(new Record(v.vList, VORONOI, true));
                #endregion
            
                foreach (Edge i in hpList)
                    v.vList.Add(new Edge(i.A, i.B, i.a, i.b));
                record.Add(new Record(v.vList, MERGE, true));
        }
            catch(Exception e)
            {
                //MessageBox.Show("Coming Soon...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return v;
        }
        /// <summary>
        /// 取得上下切線
        /// </summary>
        /// <param name="pListL">左半部的點集合</param>
        /// <param name="pListR">左半部的點集合</param>
        /// <returns>上下切線</returns>
        public List<Edge> GetTangent(List<PointF> pListL, List<PointF> pListR)
        {
            List<Edge> tangent = new List<Edge>();
            List<PointF> pList = new List<PointF>();
            List<PointF> chList;

            pList.AddRange(pListL);
            pList.AddRange(pListR);
            pList = MathEx.SortPointF(pList);
            chList = MathEx.GetConvexHull(pList);            

            for (int i = 0; i < chList.Count; i++)
            {
                if ((pListL.Contains(chList[i]) && pListR.Contains(chList[(i + 1) % chList.Count])) || (pListR.Contains(chList[i]) && pListL.Contains(chList[(i + 1) % chList.Count])))
                    tangent.Add(new Edge(chList[i], chList[(i + 1) % chList.Count]));
            }

            record.Add(new Record(chList, tangent, CONVEX_HULL, true));
            return tangent;
        }
        #endregion

        #region 延伸A點到B點的直線(求邊界座標)
        /// <summary>
        /// 延伸A點到B點的直線(求邊界座標)
        /// </summary>
        /// <param name="A">點A</param>
        /// <param name="B">點B</param>
        /// <returns>邊界座標</returns>
        public PointF GetSidePointF(PointF A, PointF B)
        {
            float X_MAX = paint_pic.Size.Width;
            float Y_MAX = paint_pic.Size.Height;
            float dx = B.X - A.X;
            float dy = B.Y - A.Y;

            /* 兩點重疊 */
                    if (dx == 0 && dy == 0)
            {
                return new PointF(A.X, A.Y);
            }
            /* 垂直線 */
            else if (dx == 0)
            {
                return (B.Y - A.Y) > 0 ? new PointF(A.X, Y_MAX) : new PointF(A.X, 0);
            }
            /* 水平線 */
            else if(dy == 0)
            {
                return (B.X - A.X) > 0 ? new PointF(X_MAX, A.Y) : new PointF(0, A.Y);
            }
            else
            {
                float m = dy / dx;          // 斜率
                float c = A.Y - m * A.X;    // 截距
                /*  y = mx + c , x = (y-c)/m  */
                /* x = 0 */
                if(c >= 0 && c <= Y_MAX)
                {
                    /* m < 0: 往右上斜; m > 0: 往右下斜 */
                    if((m < 0 && dy > 0) || (m > 0 && dy < 0))
                    {
                        return new PointF(0, c);
                    }
                }
                /* x = X_MAX */
                if (X_MAX * m + c >= 0 && X_MAX * m + c <= Y_MAX)
                {
                    if ((m < 0 && dy < 0) || (m > 0 && dy > 0))
                    {
                        return new PointF(X_MAX, X_MAX * m + c);
                    }
                }
                /* y = 0 */
                if (-c / m > 0 && -c / m < X_MAX)
                {
                    if ((m < 0 && dy < 0) || (m > 0 && dy < 0))
                    {
                        return new PointF(-c/m, 0);
                    }
                }
                /* y = Y_MAX */
                if ((Y_MAX - c) / m > 0 && (Y_MAX - c) / m < X_MAX)
                {
                    if ((m < 0 && dy > 0) || (m > 0 && dy > 0))
                    {
                        return new PointF((Y_MAX - c) / m, Y_MAX);
                    }
                }
                return new PointF();
            }
        }


        #endregion

        #endregion
    }
}
