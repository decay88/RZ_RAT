using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RZ_RAT
{
    public partial class ProcessForm : Form
    {
        public string[] client = null;
        public ProcessForm()
        {
            InitializeComponent();
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {

        }
        public void addprocesstolist(string[] processs)
        {
            int num = 0;
            foreach (string process in processs)
            {

                string processname = process.Split(new string[] { "|" }, StringSplitOptions.None)[0];
                string processpid = process.Split(new string[] { "|" }, StringSplitOptions.None)[1];
                ListViewItem lvi = new ListViewItem(num.ToString());
                lvi.SubItems.Add(processname);
                lvi.SubItems.Add(processpid);
                listView1.Items.Add(lvi);
                num++;
            }
        }
    }
}
