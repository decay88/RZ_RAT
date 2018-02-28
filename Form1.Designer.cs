namespace RZ_RAT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.flag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AntiVirus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Installtion_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dotnet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.msgboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downExecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.flag,
            this.name,
            this.IP,
            this.OS,
            this.AntiVirus,
            this.Installtion_date,
            this.dotnet});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(740, 325);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // flag
            // 
            this.flag.Text = "";
            // 
            // name
            // 
            this.name.Text = "ID ";
            this.name.Width = 129;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 151;
            // 
            // OS
            // 
            this.OS.Text = "OS";
            this.OS.Width = 107;
            // 
            // AntiVirus
            // 
            this.AntiVirus.Text = "AV";
            this.AntiVirus.Width = 121;
            // 
            // Installtion_date
            // 
            this.Installtion_date.Text = "installtion date";
            this.Installtion_date.Width = 105;
            // 
            // dotnet
            // 
            this.dotnet.Text = ".net";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgboxToolStripMenuItem,
            this.processListToolStripMenuItem,
            this.downExecToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 76);
            // 
            // msgboxToolStripMenuItem
            // 
            this.msgboxToolStripMenuItem.Name = "msgboxToolStripMenuItem";
            this.msgboxToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.msgboxToolStripMenuItem.Text = "File Manger";
            this.msgboxToolStripMenuItem.Click += new System.EventHandler(this.msgboxToolStripMenuItem_Click);
            // 
            // processListToolStripMenuItem
            // 
            this.processListToolStripMenuItem.Name = "processListToolStripMenuItem";
            this.processListToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.processListToolStripMenuItem.Text = "Process list";
            this.processListToolStripMenuItem.Click += new System.EventHandler(this.processListToolStripMenuItem_Click);
            // 
            // downExecToolStripMenuItem
            // 
            this.downExecToolStripMenuItem.Name = "downExecToolStripMenuItem";
            this.downExecToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.downExecToolStripMenuItem.Text = "down & exec";
            this.downExecToolStripMenuItem.Click += new System.EventHandler(this.downExecToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 325);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 44);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(208, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Selected :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(104, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bots :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = ".: RZ-RAT :.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader flag;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader OS;
        private System.Windows.Forms.ColumnHeader AntiVirus;
        private System.Windows.Forms.ColumnHeader Installtion_date;
        private System.Windows.Forms.ColumnHeader dotnet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem msgboxToolStripMenuItem;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem processListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downExecToolStripMenuItem;
    }
}

