using System;
using System.Windows.Forms;

namespace CSharp_LB6
{
    public partial class UserNameDialog : Form
    {
        public string userName = string.Empty;
        public UserNameDialog()
        {
            this.ControlBox=false;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNickName.Text == string.Empty)
                MessageBox.Show("Введіть ім'я!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                userName = textBoxNickName.Text;
                this.Close();
            }
        }
    }
}