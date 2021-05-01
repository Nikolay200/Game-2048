using System;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.Name = nameTextBox.Text;
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Пустая строка");

                return;
            }
 
            user.Name.ToCharArray();
            for (int i = 0; i < user.Name.Length; i++)
            {
                
                if(!char.IsLetter(user.Name[i]))
                {
                    
                    MessageBox.Show("Строка должна содержать только буквы!");
                    nameTextBox.Clear();
                    return;
                }
                else
                {
                    return;
                }
            }
                
        }

      
    }
}
