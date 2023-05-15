using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharp_LB6
{
    public partial class DialogChangeAccessFile : Form
    {
        private List<UserFile> _userFiles;
        private int _index;
        private bool isSaved = false;
        internal DialogChangeAccessFile(List<UserFile> userFiles, int index)
        {
            this.ControlBox = false;
            InitializeComponent();
            _userFiles = userFiles;
            _index = index;
            labelFileName.Text = "Назва: " + userFiles[index].name;
            checkBoxFileStatus.Checked = userFiles[index].isAvailable;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _userFiles[_index].isAvailable = checkBoxFileStatus.Checked;
            isSaved = true;
            this.Close();
        }
        
        private void DialogChangeAccessFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isSaved;
        }
    }
}