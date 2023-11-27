namespace ForcePlatformCore
{
    public partial class CommentDialogForm : Form
    {
        public string Comment = "";
        public CommentDialogForm(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Comment = richTextBox1.Text;
            this.Close();
        }
    }
}
