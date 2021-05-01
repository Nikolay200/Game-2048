using System;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class UserForm : System.Windows.Forms.Form
    {
        private string name = "Неизвестно";
        public UserForm()
        {
            InitializeComponent();
            
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UserNameTextBox.Focus();
      
        }

        private  void buttonOK_Click(object sender, EventArgs e)
        {
            name = UserNameTextBox.Text;
            if (UserNameTextBox.Text != string.Empty)
            {
                return; 
            }
            
        }
 
    }
}
