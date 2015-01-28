using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DSW.Properties;

namespace DSW
{
    public partial class FilterForm : Form
    {
        private readonly string _filter = "";
        private readonly BindingSource _bs = new BindingSource();
        private DataView _dw;
        public FilterForm(string filter)
        {
            InitializeComponent();
            Text = string.Format("Filtered {0}", filter);

            _dw = new DataView(Updater.Table);
            _bs.DataSource = _dw;
            
            _filter = StringUtils.EscapeLikeValue(filter);
            _bs.Filter = string.Format("Name like '%{0}%' OR System like '%{0}%'", _filter);
            dataGridView1.DataSource = _bs;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[1].Visible = false;

            Updater.Online.Refreshed += Online_Refreshed;

        }

        void Online_Refreshed(PlayerList m, EventArgs e)
        {
            _dw = null;
            _dw = new DataView(m.Table);
            _bs.DataSource = _dw;
            dataGridView1.DataSource = _bs;
            _bs.Filter = string.Format("Name like '%{0}%' OR System like '%{0}%'", _filter);
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[5].Visible = checkBox1.Checked;
            dataGridView1.Columns[4].Visible = checkBox1.Checked;
            dataGridView1.Columns[3].Visible = checkBox1.Checked;
            dataGridView1.Columns[1].Visible = checkBox3.Checked;
            dataGridView1.Refresh();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void FilterForm_SizeChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Height = Convert.ToInt32(Height - 100);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Padding = col.Width > 64 ? new Padding(16, 0, 0, 0) : new Padding(0, 0, 0, 0);

            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (checkBox2.Checked)
            {
                var formattedValue = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue;
                if (formattedValue != null)
                    switch ((string)formattedValue)
                    {
                        case "New":
                            {
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.NewBackColor;
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.NewForeColor;
                                break;
                            }
                        case "Moved":
                            {
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.MovBackColor;
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.MovForeColor;
                                break;
                            }
                        case "FoundPlayer":
                            {
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.PlTabBackColor;
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.PlTabForeColor;
                                break;
                            }
                        case "FoundLocation":
                            {
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.LocBackColor;
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.LocForeColor;
                                break;
                            }
                    }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns[5].Visible = checkBox1.Checked;
            dataGridView1.Columns[4].Visible = checkBox1.Checked;
            dataGridView1.Columns[3].Visible = checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns[1].Visible = checkBox3.Checked;
        }

        private void FilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mf = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mf != null) mf.RemoveFilForm(this);
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.CivBomb;
        }

    }
}
