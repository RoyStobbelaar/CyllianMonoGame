using CyllianMonoGame.Level;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyllianWorldMaker
{
    public partial class Form1 : Form
    {
        public Map CurrentMap { get; set; }
        public int HeightInTiles { get; set; }
        public int WidthIntiles { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create new Map
            this.CurrentMap = new Map();

            LoadDefaultMap();
        }

        /// <summary>
        /// Save map info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CurrentMap.Name = textBox3.Text;
            HeightInTiles = int.Parse(textBox1.Text);
            WidthIntiles = int.Parse(textBox2.Text);
        }

        private void LoadDefaultMap()
        {

        }
    }
}
