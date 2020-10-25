using System.Diagnostics;
using System.Windows.Forms;

namespace MotionDecoder.Forms
{
    public partial class About : Form
    {
        public About() =>
            InitializeComponent();

        void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start(githubLink.Text);
    }
}
