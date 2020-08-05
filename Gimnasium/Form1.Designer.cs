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
            this.SuspendLayout();
            // 
            // buttonBell
            // 
            this.buttonBell.Location = new System.Drawing.Point(12, 12);
            this.buttonBell.Name = "buttonBell";
            this.buttonBell.Size = new System.Drawing.Size(75, 23);
            this.buttonBell.TabIndex = 0;
            this.buttonBell.Text = "Звонок";
            this.buttonBell.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(93, 12);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 24);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBoxIpAdress
            // 
            this.comboBoxIpAdress.FormattingEnabled = true;
            this.comboBoxIpAdress.Location = new System.Drawing.Point(566, 17);
            this.comboBoxIpAdress.Name = "comboBoxIpAdress";
            this.comboBoxIpAdress.Size = new System.Drawing.Size(185, 21);
            this.comboBoxIpAdress.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 450);
            this.Controls.Add(this.comboBoxIpAdress);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonBell);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBell;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBoxIpAdress;
    }
}

