using System;
using System.Linq;
using System.Windows.Forms;
using DSW.Properties;
using NeoTabControlLibrary;

namespace DSW
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.CivBomb;
            neoTabWindow1.Renderer = AddInRendererManager.LoadRenderer("AvastRenderer");
            numericUpDown1.Value = (decimal)((double)Properties.Settings.Default.RefInterval / 60000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textboxPLCol.ForeColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textboxPLCol.BackColor = colorDialog1.Color;
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxLoCol.ForeColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxLoCol.BackColor = colorDialog1.Color;
            }
        }

        //change refresh interval
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RefInterval = (int)(numericUpDown1.Value*60000);
            Updater.SetInterval();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var _mf = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            _mf.ClearBaseLog();
        }


    }
}
