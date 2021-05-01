using System;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class GameTypeForm : Form
    {
        
        public GameTypeForm()
        {
            InitializeComponent();
           
        }

        private void GameTypeForm_Load(object sender, EventArgs e)
        {

            

        }

        private void button4X4_Click(object sender, EventArgs e)
        {
            MainForm.mapSize = 4;            
            
            this.Close();
        }

        private void button5X5_Click(object sender, EventArgs e)
        {
            MainForm.mapSize = 5;           
           
            this.Close();
        }
        private void GameTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        
    }
}
