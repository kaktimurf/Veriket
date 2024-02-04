namespace Veriket.WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCsv = new Button();
            dataGridView1 = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            pcName = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnCsv
            // 
            btnCsv.AllowDrop = true;
            btnCsv.AutoSize = true;
            btnCsv.BackColor = Color.AliceBlue;
            btnCsv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCsv.Location = new Point(305, 26);
            btnCsv.Name = "btnCsv";
            btnCsv.Size = new Size(118, 42);
            btnCsv.TabIndex = 0;
            btnCsv.Text = "Logları Getir";
            btnCsv.UseVisualStyleBackColor = false;
            btnCsv.Click += btnCsv_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.LemonChiffon;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { date, pcName, username });
            dataGridView1.Location = new Point(35, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(648, 257);
            dataGridView1.TabIndex = 1;
            // 
            // date
            // 
            date.HeaderText = "Tarih";
            date.Name = "date";
            // 
            // pcName
            // 
            pcName.HeaderText = "Bilgisayar Adı";
            pcName.Name = "pcName";
            // 
            // username
            // 
            username.HeaderText = "Kullanıcı Adı";
            username.Name = "username";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 387);
            Controls.Add(dataGridView1);
            Controls.Add(btnCsv);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Veriket Win Form";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCsv;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn pcName;
        private DataGridViewTextBoxColumn username;
    }
}
