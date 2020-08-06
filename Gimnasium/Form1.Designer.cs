namespace Gimnasium
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonBell = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBoxIpAdress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableBell = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tableBell)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBell
            // 
            this.buttonBell.BackColor = System.Drawing.Color.Brown;
            this.buttonBell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBell.ForeColor = System.Drawing.Color.White;
            this.buttonBell.Location = new System.Drawing.Point(12, 36);
            this.buttonBell.Name = "buttonBell";
            this.buttonBell.Size = new System.Drawing.Size(225, 44);
            this.buttonBell.TabIndex = 0;
            this.buttonBell.Text = "Звонок";
            this.buttonBell.UseVisualStyleBackColor = false;
            this.buttonBell.Click += new System.EventHandler(this.buttonBell_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.Color.Green;
            this.labelTime.Location = new System.Drawing.Point(85, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(66, 24);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "label1";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBoxIpAdress
            // 
            this.comboBoxIpAdress.FormattingEnabled = true;
            this.comboBoxIpAdress.Location = new System.Drawing.Point(12, 378);
            this.comboBoxIpAdress.Name = "comboBoxIpAdress";
            this.comboBoxIpAdress.Size = new System.Drawing.Size(225, 21);
            this.comboBoxIpAdress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // tableBell
            // 
            this.tableBell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableBell.Location = new System.Drawing.Point(12, 96);
            this.tableBell.Name = "tableBell";
            this.tableBell.Size = new System.Drawing.Size(225, 141);
            this.tableBell.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(251, 411);
            this.Controls.Add(this.tableBell);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxIpAdress);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonBell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Управление звонком";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableBell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBell;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBoxIpAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tableBell;
    }
}

