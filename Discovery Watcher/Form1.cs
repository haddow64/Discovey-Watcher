using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DSW.popup;
using DSW.Properties;
using DSW.tables;
using NeoTabControlLibrary;

namespace DSW
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bs = new BindingSource();
        private readonly List<FilterForm> _filforms = new List<FilterForm>(); 
        public Form1()
        {
            InitializeComponent();
        }

        #region "form events"

        private void Form1_Load(object sender, EventArgs e)
        {
            Icon = Resources.CivBomb;
            neoTabWindow1.SelectedIndex = 0;
            neoTabWindow1.Renderer = AddInRendererManager.LoadRenderer("CCleanerRendererVS4");

            _bs.DataSource = Updater.Table;
            Grid.DataSource = _bs;
            Grid.Height = Convert.ToInt32(TabPagePlList.Height - textBox1.Height - 10);
            Grid.Columns[0].MinimumWidth = 175;
            Grid.Columns[1].MinimumWidth = 150;
            Grid.Columns[2].MinimumWidth = 125;
            Grid.Columns[3].MinimumWidth = 60;
            Grid.Columns[4].MinimumWidth = 30;
            Grid.Columns[5].MinimumWidth = 30;
            Grid.Columns[6].Visible = false;
            Grid.Focus();
            helpProvider1.SetHelpString(dataGridView3,"Enter full player name or part of the name (i.e. tag), and you'll receive notification when any player matching would log in. Clear the line to remove it. \r\n \r\n For example, string \"[Ange\" will trigger any [Angels], as well as Bla[Angedurdur \r\n \"D\" will trigger any player with a letter D (capital or not) in their name.");
            helpProvider1.SetHelpString(dataGridView2, "Works like Player Search, but you can specify the system name or its part to trigger, or you can enter only system name to trigger anyone entering this system. \r\n Clear system name field to remove the whole entry.");
            Updater.Tick();

            dataGridView2.DataSource = Updater.LocationWatch.Table;
            dataGridView3.DataSource = Updater.PlayerWatch.Table;
            dataGridView4.DataSource = Updater.Tags.Table;

            Updater.Online.Refreshed += Online_Refreshed;

            if (Settings.Default.WatchBase)
            {
                checkBox1_CheckedChanged(this,e);
            }

            if (File.Exists("base.log"))
            {
                richTextBox2.Text = File.ReadAllText("base.log");
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Grid.Height = Convert.ToInt32(TabPagePlList.Height - textBox1.Height - 10);
            dataGridView4.Height = Convert.ToInt32(TabPagePlList.Height - textBox1.Height - 10);
            foreach (DataGridViewColumn col in Grid.Columns)
            {
                col.HeaderCell.Style.Padding = col.Width > 64 ? new Padding(16, 0, 0, 0) : new Padding(0, 0, 0, 0);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
            Application.Exit();
        }

        #endregion

        private DataGridView Grid { get; set; }

        #region "tbox filters"
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _bs.Filter = string.Format("Name like '%{0}%' OR System like '%{0}%'", StringUtils.EscapeLikeValue(textBox1.Text.Trim()));
            button1.Enabled = textBox1.Text != "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView4.DataSource).DefaultView.RowFilter = string.Format("Tag like '%{0}%' OR Faction like '%{0}%' OR IFF  like '%{0}%' OR ID like '%{0}%' OR Leader like '%{0}%'", StringUtils.EscapeLikeValue(textBox2.Text.Trim().Replace("'", "''")));
        }
        #endregion

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var formattedValue = Grid.Rows[e.RowIndex].Cells[6].FormattedValue;
            if (formattedValue != null)
                switch ((string)formattedValue)
                {
                    case "New":
                        {
                            Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.NewBackColor;
                            Grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.NewForeColor;
                            break;
                        }
                    case "Moved":
                        {
                            Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.MovBackColor;
                            Grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.MovForeColor;
                            break;
                        }
                    case "FoundPlayer":
                        {
                            Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.PlTabBackColor;
                            Grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.PlTabForeColor;
                            break;
                        }
                    case "FoundLocation":
                        {
                            Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Settings.Default.LocBackColor;
                            Grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Settings.Default.LocForeColor;
                            break;
                        }
                }
        }



        #region "mainmenu"
        private void manualUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater.Tick();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pfrm = new SettingsForm();
            pfrm.ShowDialog();
        }
        #endregion

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Grid.ClearSelection();
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    Grid.Rows[rowSelected].Selected = true;
                }
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        #region "toolstrip"
        private void addToWatchPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curRow = Grid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            Updater.PlayerWatch.Table.Rows.Add((string) Grid.Rows[curRow].Cells[0].FormattedValue);
        }

        private void addToWatchLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 curRow = Grid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            Updater.LocationWatch.Table.Rows.Add((string)Grid.Rows[curRow].Cells[0].FormattedValue, (string)Grid.Rows[curRow].Cells[2].FormattedValue);
        }

        private void tagLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 curRow = Grid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            textBox2.Text = (string) Grid.Rows[curRow].Cells[1].FormattedValue;
            neoTabWindow1.SelectedIndex = 2;
        }
        #endregion

        #region "entry removal handles"
        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) & !(dataGridView3.Rows[e.RowIndex].IsNewRow))
            {
                if ((string) dataGridView3.Rows[e.RowIndex].Cells[0].FormattedValue == "")
                {
                    dataGridView3.Rows.Remove(dataGridView3.Rows[e.RowIndex]);
                }
                    Updater.RescanPlayers();
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) & !(dataGridView2.Rows[e.RowIndex].IsNewRow))
            {
                if ((string)dataGridView2.Rows[e.RowIndex].Cells[1].FormattedValue == "")
                {
                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                }
                Updater.RescanPlayers();
            }
        }

        private void dataGridView3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Updater.RescanPlayers();
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Updater.RescanPlayers();
        }

        private void dataGridView3_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Updater.RescanPlayers();
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Updater.RescanPlayers();
        }

        #endregion

        #region "filterforms"
        private void button1_Click(object sender, EventArgs e)
        {
            var ff = new FilterForm(textBox1.Text);
            _filforms.Add(ff);
            ff.Show();
        }

        public void RemoveFilForm(FilterForm form)
        {
            _filforms.Remove(form);
        }
        #endregion

        void Online_Refreshed(PlayerList m, EventArgs e)
        {
            _bs.DataSource = m.Table;
            Grid.Refresh();
        }

        #region "notifyicon tstrip"

        private void openWatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void preferencesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var pf = new SettingsForm();
            pf.Show();
        }

        private void MinToTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500, "DS Watcher", "Application running in background.", ToolTipIcon.Info);
            Hide();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
                BringToFront();
                Activate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                MinToTray();
            }
        }

        #endregion

        #region "basewatch refresh"

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Updater.Base.Refreshed += Base_Refreshed;
                Updater.Base.Tick();
                comboBox1.Text = Resources.BaseWatchUpdating;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.BaseName = comboBox1.Text;
            string[] status = Updater.Base.GetStatus(comboBox1.SelectedIndex);
            richTextBox1.Text = Regex.Replace(status[0].Replace("&nbsp;&nbsp;", "").Replace("<p>", "\r\n\r\n"), @"<[^>]*>", String.Empty);
            BaseLogEvent("-------------");
            BaseLogEvent(string.Format("Base changed: {0}", comboBox1.Text));
            BaseLogEvent("-------------");
            textBox3.Text = status[1];
            textBox4.Text = status[2];
            textBox5.Text = status[3];
        }

        private void Base_Refreshed(Base m, EventArgs e)
        {
            comboBox1.Items.AddRange(m.GetNames);
            comboBox1.Enabled = true;
            comboBox1.SelectedIndex = GetBaseIndex();

            string[] status = Updater.Base.GetStatus(comboBox1.SelectedIndex);
            if (textBox3.Text != "")
            {
                if ((textBox3.Text != status[1]) | textBox4.Text != status[2])
                {
                    if (Settings.Default.UseNotif)
                    {
                        Notifier.Pop(string.Format("{0} \r\n State changed! H:{1} S:{2}",comboBox1.Text,status[1],status[2]));
                    }
                    BaseWriteDownAttackers(status[1], status[2]);
                }

                if (textBox5.Text != status[3])
                {
                    BaseLogEvent(string.Format("Cash changed: previous amount: {0} current: {1}", textBox5.Text, status[3]));
                }
            }

            textBox3.Text = status[1];
            textBox4.Text = status[2];
            textBox5.Text = status[3];
        }

        private int GetBaseIndex()
        {
            if (Settings.Default.BaseName == "")
            {
                return 0; 
            }
            int ind = comboBox1.Items.IndexOf(Settings.Default.BaseName);
            if (ind == -1)
            {
                ind = 0;
            }

            return ind;
        }

        
        private void BaseWriteDownAttackers(string health,string shield)
        {
            BaseLogEvent(string.Format("Health parameters changed! {0},{1} Possible attackers: ",health,shield));
            BaseLogEvent(Updater.Online.GetSystem());
        }

        private void BaseLogEvent(string text)
        {
            richTextBox2.Text += string.Format(" {0} : {1} \r\n", DateTime.Now, text);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("base.log", richTextBox2.Text);
        }

        public void ClearBaseLog()
        {
            richTextBox2.Text = "";
            BaseLogEvent("Log cleared");
        }

        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new AboutBox1();
            ab.Show();
        }

        private void dataGridView4_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((string) dataGridView4.Rows[e.RowIndex].Cells[0].FormattedValue == "")
                {
                    dataGridView4.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}