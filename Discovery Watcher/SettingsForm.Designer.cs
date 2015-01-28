namespace DSW
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.neoTabWindow1 = new NeoTabControlLibrary.NeoTabWindow();
            this.neoTabPage2 = new NeoTabControlLibrary.NeoTabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.neoTabPage1 = new NeoTabControlLibrary.NeoTabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxLoCol = new System.Windows.Forms.TextBox();
            this.textboxPLCol = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).BeginInit();
            this.neoTabWindow1.SuspendLayout();
            this.neoTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.neoTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neoTabWindow1
            // 
            this.neoTabWindow1.Controls.Add(this.neoTabPage2);
            this.neoTabWindow1.Controls.Add(this.neoTabPage1);
            this.neoTabWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neoTabWindow1.Location = new System.Drawing.Point(0, 0);
            this.neoTabWindow1.Name = "neoTabWindow1";
            this.neoTabWindow1.RendererName = "AvastRenderer";
            this.neoTabWindow1.SelectedIndex = 0;
            this.neoTabWindow1.Size = new System.Drawing.Size(627, 335);
            this.neoTabWindow1.TabIndex = 0;
            // 
            // neoTabPage2
            // 
            this.neoTabPage2.Controls.Add(this.button9);
            this.neoTabPage2.Controls.Add(this.label6);
            this.neoTabPage2.Controls.Add(this.numericUpDown1);
            this.neoTabPage2.Controls.Add(this.label5);
            this.neoTabPage2.Controls.Add(this.checkBox2);
            this.neoTabPage2.Controls.Add(this.checkBox1);
            this.neoTabPage2.IsCloseable = false;
            this.neoTabPage2.Name = "neoTabPage2";
            this.neoTabPage2.Text = "General";
            this.neoTabPage2.ToolTipText = "General";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "minutes";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(96, 60);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 22);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Refresh interval";
            // 
            // neoTabPage1
            // 
            this.neoTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.neoTabPage1.Controls.Add(this.button7);
            this.neoTabPage1.Controls.Add(this.button8);
            this.neoTabPage1.Controls.Add(this.label4);
            this.neoTabPage1.Controls.Add(this.textBox2);
            this.neoTabPage1.Controls.Add(this.button5);
            this.neoTabPage1.Controls.Add(this.button6);
            this.neoTabPage1.Controls.Add(this.label3);
            this.neoTabPage1.Controls.Add(this.textBox1);
            this.neoTabPage1.Controls.Add(this.button3);
            this.neoTabPage1.Controls.Add(this.button4);
            this.neoTabPage1.Controls.Add(this.label2);
            this.neoTabPage1.Controls.Add(this.textBoxLoCol);
            this.neoTabPage1.Controls.Add(this.button2);
            this.neoTabPage1.Controls.Add(this.button1);
            this.neoTabPage1.Controls.Add(this.label1);
            this.neoTabPage1.Controls.Add(this.textboxPLCol);
            this.neoTabPage1.IsCloseable = false;
            this.neoTabPage1.Name = "neoTabPage1";
            this.neoTabPage1.Text = "Appearance";
            this.neoTabPage1.ToolTipText = "Appearance";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(353, 101);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(79, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Background";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(272, 101);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Font Color";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Player moved";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(353, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Background";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(272, 70);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Font Color";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "New player";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Background";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Font Color";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player found in Location List";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Background";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Font Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player found in Players List";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::DSW.Properties.Settings.Default.UseNotif;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DSW.Properties.Settings.Default, "UseNotif", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(8, 14);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(123, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Show notifications";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::DSW.Properties.Settings.Default.UseSound;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DSW.Properties.Settings.Default, "UseSound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::DSW.Properties.Settings.Default, "UseNotif", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Enabled = global::DSW.Properties.Settings.Default.UseNotif;
            this.checkBox1.Location = new System.Drawing.Point(8, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Use sounds";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = global::DSW.Properties.Settings.Default.MovBackColor;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::DSW.Properties.Settings.Default, "MovBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::DSW.Properties.Settings.Default, "MovForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = global::DSW.Properties.Settings.Default.MovForeColor;
            this.textBox2.Location = new System.Drawing.Point(166, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "BoomBaum";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = global::DSW.Properties.Settings.Default.NewBackColor;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::DSW.Properties.Settings.Default, "NewForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::DSW.Properties.Settings.Default, "NewBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = global::DSW.Properties.Settings.Default.NewForeColor;
            this.textBox1.Location = new System.Drawing.Point(166, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "BoomBaum";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLoCol
            // 
            this.textBoxLoCol.BackColor = global::DSW.Properties.Settings.Default.LocBackColor;
            this.textBoxLoCol.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::DSW.Properties.Settings.Default, "LocBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxLoCol.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::DSW.Properties.Settings.Default, "LocForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxLoCol.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLoCol.ForeColor = global::DSW.Properties.Settings.Default.LocForeColor;
            this.textBoxLoCol.Location = new System.Drawing.Point(166, 38);
            this.textBoxLoCol.Name = "textBoxLoCol";
            this.textBoxLoCol.Size = new System.Drawing.Size(100, 25);
            this.textBoxLoCol.TabIndex = 4;
            this.textBoxLoCol.Text = "BoomBaum";
            this.textBoxLoCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textboxPLCol
            // 
            this.textboxPLCol.BackColor = global::DSW.Properties.Settings.Default.PlTabBackColor;
            this.textboxPLCol.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::DSW.Properties.Settings.Default, "PlTabBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textboxPLCol.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::DSW.Properties.Settings.Default, "PlTabForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textboxPLCol.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPLCol.ForeColor = global::DSW.Properties.Settings.Default.PlTabForeColor;
            this.textboxPLCol.Location = new System.Drawing.Point(166, 5);
            this.textboxPLCol.Name = "textboxPLCol";
            this.textboxPLCol.Size = new System.Drawing.Size(100, 25);
            this.textboxPLCol.TabIndex = 0;
            this.textboxPLCol.Text = "BoomBaum";
            this.textboxPLCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(36, 96);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(107, 23);
            this.button9.TabIndex = 5;
            this.button9.Text = "Clear Base Log";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 335);
            this.Controls.Add(this.neoTabWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).EndInit();
            this.neoTabWindow1.ResumeLayout(false);
            this.neoTabPage2.ResumeLayout(false);
            this.neoTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.neoTabPage1.ResumeLayout(false);
            this.neoTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private NeoTabControlLibrary.NeoTabWindow neoTabWindow1;
        private NeoTabControlLibrary.NeoTabPage neoTabPage1;
        private NeoTabControlLibrary.NeoTabPage neoTabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxPLCol;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLoCol;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button9;

    }
}