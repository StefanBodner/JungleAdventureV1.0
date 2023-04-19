using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCreator
{
    public partial class frm_WorldSelection : Form
    {
        public frm_WorldSelection()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_creator_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_creator frmcreator = new frm_creator();
            frmcreator.ShowDialog();
            this.Show();
        }

        private void LevelSelection(int selectedLevel)
        {
            string filePath = Path.Combine("Data", "selectedLevel.txt");

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // If the file doesn't exist, create it
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(selectedLevel);
                }
            }
            else
            {
                File.WriteAllText(filePath, selectedLevel.ToString());
            }
        }
        private void GameStart()
        {
            string filename = "JungleAdventure.exe";
            string path = Path.GetFullPath(filename);
            string replacedpath = path.Replace(@"\WorldCreation\WorldCreator\bin\Debug\JungleAdventure.exe", @"\JungleAdventure\bin\Debug\net6.0\JungleAdventure.exe");
            string newpath = replacedpath.Replace(@"\", @"\\");

            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = newpath;
                    myProcess.StartInfo.CreateNoWindow = true;
                    this.Hide();
                    myProcess.Start();
                    myProcess.WaitForExit();
                    this.Show();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btn_world1_Click(object sender, EventArgs e)
        {
            LevelSelection(1);
            GameStart();
        }
        private void btn_world2_Click(object sender, EventArgs e)
        {
            LevelSelection(2);
            GameStart();
        }

        private void btn_world3_Click(object sender, EventArgs e)
        {
            LevelSelection(3);
            GameStart();
        }

        private void btn_world4_Click(object sender, EventArgs e)
        {
            LevelSelection(4);
            GameStart();
        }

        private void btn_world5_Click(object sender, EventArgs e)
        {
            LevelSelection(5);
            GameStart();
        }

        private void btn_world6_Click(object sender, EventArgs e)
        {
            LevelSelection(6);
            GameStart();
        }
    }
}
