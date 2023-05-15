using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CSharp_LB6
{
    public partial class DialogAboutFile : Form
    {
        public UserFile userFile;
        private List<UserFile> _userFiles;

        private void SetScreenInfo()
        {
            labelName.Text = userFile.name;
            labelWeight.Text = (userFile.fileWeight / 1000000).ToString() + " мб.";
            labelPath.Text = userFile.path;
            labelDataCreate.Text = userFile.createDate.ToString(CultureInfo.InvariantCulture);
        }
        
        internal DialogAboutFile(UserFile getUserFile, List<UserFile> userFiles)
        {
            userFile = getUserFile;
            _userFiles = userFiles; 
            InitializeComponent();
            this.ControlBox = false;
            SetScreenInfo();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            userFile.isAvailable = checkBoxIsAvailable.Checked;
            this.Close();
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            userFile = null;
            this.Close();
        }

        private void buttonChooseAnother_Click(object sender, EventArgs e)
        {
            var functions = new Functions();
            var newUserFile = functions.SelectFile(false, _userFiles);
            if (newUserFile.name != null)
            {
                userFile = newUserFile;
                SetScreenInfo();
            }
        }
    }
}
