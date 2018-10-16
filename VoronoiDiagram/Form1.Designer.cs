namespace VoronoiDiagram
{
    partial class main_form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.buttom_status = new System.Windows.Forms.StatusStrip();
            this.info_statuslbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.top_menu = new System.Windows.Forms.MenuStrip();
            this.file_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.run_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.step_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_mitem = new System.Windows.Forms.ToolStripMenuItem();
            this.node_lbx = new System.Windows.Forms.ListBox();
            this.open_fdg = new System.Windows.Forms.OpenFileDialog();
            this.save_fdg = new System.Windows.Forms.SaveFileDialog();
            this.paint_pic = new System.Windows.Forms.PictureBox();
            this.top_tol = new System.Windows.Forms.ToolStrip();
            this.clear_btn = new System.Windows.Forms.ToolStripButton();
            this.open_btn = new System.Windows.Forms.ToolStripButton();
            this.save_btn = new System.Windows.Forms.ToolStripButton();
            this.next_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.run_btn = new System.Windows.Forms.ToolStripButton();
            this.step_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.x_lbl = new System.Windows.Forms.ToolStripLabel();
            this.x_txt = new System.Windows.Forms.ToolStripTextBox();
            this.y_lbl = new System.Windows.Forms.ToolStripLabel();
            this.y_txt = new System.Windows.Forms.ToolStripTextBox();
            this.add_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.amount_lbl = new System.Windows.Forms.ToolStripLabel();
            this.amount_txt = new System.Windows.Forms.ToolStripTextBox();
            this.random_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.about_btn = new System.Windows.Forms.ToolStripButton();
            this.buttom_status.SuspendLayout();
            this.top_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paint_pic)).BeginInit();
            this.top_tol.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttom_status
            // 
            this.buttom_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info_statuslbl});
            this.buttom_status.Location = new System.Drawing.Point(0, 665);
            this.buttom_status.Name = "buttom_status";
            this.buttom_status.Size = new System.Drawing.Size(713, 22);
            this.buttom_status.TabIndex = 0;
            this.buttom_status.Text = "statusStrip1";
            // 
            // info_statuslbl
            // 
            this.info_statuslbl.Name = "info_statuslbl";
            this.info_statuslbl.Size = new System.Drawing.Size(29, 17);
            this.info_statuslbl.Text = "info";
            // 
            // top_menu
            // 
            this.top_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_mitem,
            this.edit_mitem});
            this.top_menu.Location = new System.Drawing.Point(0, 0);
            this.top_menu.Name = "top_menu";
            this.top_menu.Size = new System.Drawing.Size(713, 24);
            this.top_menu.TabIndex = 2;
            this.top_menu.Text = "menuStrip1";
            // 
            // file_mitem
            // 
            this.file_mitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_mitem,
            this.save_mitem,
            this.exit_mitem});
            this.file_mitem.Name = "file_mitem";
            this.file_mitem.Size = new System.Drawing.Size(38, 20);
            this.file_mitem.Text = "File";
            // 
            // open_mitem
            // 
            this.open_mitem.Name = "open_mitem";
            this.open_mitem.Size = new System.Drawing.Size(106, 22);
            this.open_mitem.Text = "Open";
            this.open_mitem.Click += new System.EventHandler(this.open_mitem_Click);
            // 
            // save_mitem
            // 
            this.save_mitem.Name = "save_mitem";
            this.save_mitem.Size = new System.Drawing.Size(106, 22);
            this.save_mitem.Text = "Save";
            this.save_mitem.Click += new System.EventHandler(this.save_mitem_Click);
            // 
            // exit_mitem
            // 
            this.exit_mitem.Name = "exit_mitem";
            this.exit_mitem.Size = new System.Drawing.Size(106, 22);
            this.exit_mitem.Text = "Exit";
            this.exit_mitem.Click += new System.EventHandler(this.exit_mitem_Click);
            // 
            // edit_mitem
            // 
            this.edit_mitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.run_mitem,
            this.step_mitem,
            this.clear_mitem});
            this.edit_mitem.Name = "edit_mitem";
            this.edit_mitem.Size = new System.Drawing.Size(41, 20);
            this.edit_mitem.Text = "Edit";
            // 
            // run_mitem
            // 
            this.run_mitem.Name = "run_mitem";
            this.run_mitem.Size = new System.Drawing.Size(152, 22);
            this.run_mitem.Text = "Run";
            this.run_mitem.Click += new System.EventHandler(this.run_mitem_Click);
            // 
            // step_mitem
            // 
            this.step_mitem.Name = "step_mitem";
            this.step_mitem.Size = new System.Drawing.Size(152, 22);
            this.step_mitem.Text = "Step";
            this.step_mitem.Click += new System.EventHandler(this.step_mitem_Click);
            // 
            // clear_mitem
            // 
            this.clear_mitem.Name = "clear_mitem";
            this.clear_mitem.Size = new System.Drawing.Size(152, 22);
            this.clear_mitem.Text = "Clear";
            this.clear_mitem.Click += new System.EventHandler(this.clear_mitem_Click);
            // 
            // node_lbx
            // 
            this.node_lbx.FormattingEnabled = true;
            this.node_lbx.ItemHeight = 12;
            this.node_lbx.Location = new System.Drawing.Point(618, 54);
            this.node_lbx.Name = "node_lbx";
            this.node_lbx.Size = new System.Drawing.Size(87, 604);
            this.node_lbx.TabIndex = 3;
            // 
            // open_fdg
            // 
            this.open_fdg.FileName = "vd_testdata.in";
            // 
            // save_fdg
            // 
            this.save_fdg.FileName = "vd_testdata.out";
            // 
            // paint_pic
            // 
            this.paint_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paint_pic.Location = new System.Drawing.Point(9, 54);
            this.paint_pic.Name = "paint_pic";
            this.paint_pic.Size = new System.Drawing.Size(603, 603);
            this.paint_pic.TabIndex = 0;
            this.paint_pic.TabStop = false;
            this.paint_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.paint_pic_MouseClick);
            this.paint_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_pic_MouseMove);
            // 
            // top_tol
            // 
            this.top_tol.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.top_tol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clear_btn,
            this.open_btn,
            this.save_btn,
            this.next_btn,
            this.toolStripSeparator,
            this.run_btn,
            this.step_btn,
            this.toolStripSeparator3,
            this.x_lbl,
            this.x_txt,
            this.y_lbl,
            this.y_txt,
            this.add_btn,
            this.toolStripSeparator1,
            this.amount_lbl,
            this.amount_txt,
            this.random_btn,
            this.toolStripSeparator2,
            this.about_btn});
            this.top_tol.Location = new System.Drawing.Point(0, 24);
            this.top_tol.Name = "top_tol";
            this.top_tol.Size = new System.Drawing.Size(713, 27);
            this.top_tol.TabIndex = 20;
            this.top_tol.Text = "toolStrip1";
            // 
            // clear_btn
            // 
            this.clear_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clear_btn.Image = ((System.Drawing.Image)(resources.GetObject("clear_btn.Image")));
            this.clear_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(24, 24);
            this.clear_btn.Text = "Clear";
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // open_btn
            // 
            this.open_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open_btn.Image = ((System.Drawing.Image)(resources.GetObject("open_btn.Image")));
            this.open_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(24, 24);
            this.open_btn.Text = "Open";
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_btn.Image = ((System.Drawing.Image)(resources.GetObject("save_btn.Image")));
            this.save_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(24, 24);
            this.save_btn.Text = "Save";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.next_btn.Image = ((System.Drawing.Image)(resources.GetObject("next_btn.Image")));
            this.next_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(24, 24);
            this.next_btn.Text = "Next";
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // run_btn
            // 
            this.run_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.run_btn.Image = ((System.Drawing.Image)(resources.GetObject("run_btn.Image")));
            this.run_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.run_btn.Name = "run_btn";
            this.run_btn.Size = new System.Drawing.Size(24, 24);
            this.run_btn.Text = "Run";
            this.run_btn.Click += new System.EventHandler(this.run_btn_Click);
            // 
            // step_btn
            // 
            this.step_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.step_btn.Image = ((System.Drawing.Image)(resources.GetObject("step_btn.Image")));
            this.step_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.step_btn.Name = "step_btn";
            this.step_btn.Size = new System.Drawing.Size(24, 24);
            this.step_btn.Text = "Step";
            this.step_btn.Click += new System.EventHandler(this.step_btn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // x_lbl
            // 
            this.x_lbl.Name = "x_lbl";
            this.x_lbl.Size = new System.Drawing.Size(19, 24);
            this.x_lbl.Text = "x :";
            // 
            // x_txt
            // 
            this.x_txt.Name = "x_txt";
            this.x_txt.Size = new System.Drawing.Size(40, 27);
            // 
            // y_lbl
            // 
            this.y_lbl.Name = "y_lbl";
            this.y_lbl.Size = new System.Drawing.Size(19, 24);
            this.y_lbl.Text = "y :";
            // 
            // y_txt
            // 
            this.y_txt.Name = "y_txt";
            this.y_txt.Size = new System.Drawing.Size(40, 27);
            // 
            // add_btn
            // 
            this.add_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_btn.Image = ((System.Drawing.Image)(resources.GetObject("add_btn.Image")));
            this.add_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(24, 24);
            this.add_btn.Text = "Add";
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // amount_lbl
            // 
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(58, 24);
            this.amount_lbl.Text = "Amount :";
            // 
            // amount_txt
            // 
            this.amount_txt.Name = "amount_txt";
            this.amount_txt.Size = new System.Drawing.Size(40, 27);
            // 
            // random_btn
            // 
            this.random_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.random_btn.Image = ((System.Drawing.Image)(resources.GetObject("random_btn.Image")));
            this.random_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.random_btn.Name = "random_btn";
            this.random_btn.Size = new System.Drawing.Size(24, 24);
            this.random_btn.Text = "Random";
            this.random_btn.ToolTipText = "Random";
            this.random_btn.Click += new System.EventHandler(this.random_btn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // about_btn
            // 
            this.about_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.about_btn.Image = ((System.Drawing.Image)(resources.GetObject("about_btn.Image")));
            this.about_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.about_btn.Name = "about_btn";
            this.about_btn.Size = new System.Drawing.Size(24, 24);
            this.about_btn.Text = "About";
            this.about_btn.Click += new System.EventHandler(this.about_btn_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 687);
            this.Controls.Add(this.top_tol);
            this.Controls.Add(this.paint_pic);
            this.Controls.Add(this.node_lbx);
            this.Controls.Add(this.buttom_status);
            this.Controls.Add(this.top_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.top_menu;
            this.Name = "main_form";
            this.Text = "Voronoi Diagram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_form_FormClosing);
            this.Load += new System.EventHandler(this.main_form_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.main_form_Paint);
            this.buttom_status.ResumeLayout(false);
            this.buttom_status.PerformLayout();
            this.top_menu.ResumeLayout(false);
            this.top_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paint_pic)).EndInit();
            this.top_tol.ResumeLayout(false);
            this.top_tol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip buttom_status;
        private System.Windows.Forms.ToolStripStatusLabel info_statuslbl;
        private System.Windows.Forms.MenuStrip top_menu;
        private System.Windows.Forms.ToolStripMenuItem file_mitem;
        private System.Windows.Forms.ToolStripMenuItem open_mitem;
        private System.Windows.Forms.ToolStripMenuItem save_mitem;
        private System.Windows.Forms.ToolStripMenuItem exit_mitem;
        private System.Windows.Forms.ListBox node_lbx;
        private System.Windows.Forms.OpenFileDialog open_fdg;
        private System.Windows.Forms.SaveFileDialog save_fdg;
        private System.Windows.Forms.ToolStripMenuItem edit_mitem;
        private System.Windows.Forms.ToolStripMenuItem run_mitem;
        private System.Windows.Forms.ToolStripMenuItem step_mitem;
        private System.Windows.Forms.ToolStripMenuItem clear_mitem;
        private System.Windows.Forms.PictureBox paint_pic;
        private System.Windows.Forms.ToolStrip top_tol;
        private System.Windows.Forms.ToolStripButton clear_btn;
        private System.Windows.Forms.ToolStripButton open_btn;
        private System.Windows.Forms.ToolStripButton save_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripLabel x_lbl;
        private System.Windows.Forms.ToolStripTextBox y_txt;
        private System.Windows.Forms.ToolStripLabel y_lbl;
        private System.Windows.Forms.ToolStripTextBox x_txt;
        private System.Windows.Forms.ToolStripButton add_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel amount_lbl;
        private System.Windows.Forms.ToolStripTextBox amount_txt;
        private System.Windows.Forms.ToolStripButton random_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton about_btn;
        private System.Windows.Forms.ToolStripButton next_btn;
        private System.Windows.Forms.ToolStripButton run_btn;
        private System.Windows.Forms.ToolStripButton step_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

