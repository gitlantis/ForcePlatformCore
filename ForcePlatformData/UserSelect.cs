using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForcePlatformData
{
    public partial class UserSelect : Form
    {
        public UserSelect()
        {
            InitializeComponent();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var addUserForm = new UserAddUpdate();
            addUserForm.ShowDialog();
        }
    }
}
