using System;
using System.Linq;
using System.Windows.Forms;

namespace DSW.popup
{
    public partial class ToastForm : Form
    {
        private int _vpnum = -1;

        public ToastForm(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        public Timer Timer { get; private set; }

        public void Setvp(int num)
        {
            _vpnum = num;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var mf = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mf != null)
            {
                mf.Show();
                mf.WindowState = FormWindowState.Normal;
                mf.BringToFront();
                mf.Activate();
            }
            Timer.Enabled = false;
            timerFOut.Enabled = true;
        }

        private void ToastForm_Shown(object sender, EventArgs e)
        {
            Timer.Enabled = true;
            timerFade.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            Notifier.Remove(_vpnum);
            timerFOut.Enabled = true;
        }

        private void timerFade_Tick(object sender, EventArgs e)
        {
            Opacity += 0.05;
            if (Opacity >= .95)
            {
                Opacity = 1;
                timerFade.Enabled = false;
            }
        }

        private void timerFOut_Tick(object sender, EventArgs e)
        {
            FadeClose();
        }

        private void FadeClose()
        {
            Opacity -= 0.05;
            if (Opacity <= .05)
            {
                Opacity = 0;
                timerFade.Enabled = false;

                Close();
            }
        }
    }
}