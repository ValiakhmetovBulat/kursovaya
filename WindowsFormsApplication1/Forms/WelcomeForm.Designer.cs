namespace WindowsFormsApplication1
{
    partial class WelcomeForm
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
            this.buttonBookARoom = new System.Windows.Forms.Button();
            this.buttonAddCash = new System.Windows.Forms.Button();
            this.textBoxCash = new System.Windows.Forms.TextBox();
            this.checkedListBoxServices = new System.Windows.Forms.CheckedListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonDeleteServices = new System.Windows.Forms.Button();
            this.buttonPayServices = new System.Windows.Forms.Button();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBookARoom
            // 
            this.buttonBookARoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookARoom.ForeColor = System.Drawing.Color.White;
            this.buttonBookARoom.Location = new System.Drawing.Point(511, 130);
            this.buttonBookARoom.Name = "buttonBookARoom";
            this.buttonBookARoom.Size = new System.Drawing.Size(139, 40);
            this.buttonBookARoom.TabIndex = 0;
            this.buttonBookARoom.Text = "Забронировать номер";
            this.buttonBookARoom.UseVisualStyleBackColor = true;
            this.buttonBookARoom.Click += new System.EventHandler(this.buttonBookARoom_Click);
            // 
            // buttonAddCash
            // 
            this.buttonAddCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCash.ForeColor = System.Drawing.Color.White;
            this.buttonAddCash.Location = new System.Drawing.Point(511, 39);
            this.buttonAddCash.Name = "buttonAddCash";
            this.buttonAddCash.Size = new System.Drawing.Size(139, 30);
            this.buttonAddCash.TabIndex = 2;
            this.buttonAddCash.Text = "Пополнить счет";
            this.buttonAddCash.UseVisualStyleBackColor = true;
            this.buttonAddCash.Click += new System.EventHandler(this.buttonAddCash_Click);
            // 
            // textBoxCash
            // 
            this.textBoxCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCash.Location = new System.Drawing.Point(511, 10);
            this.textBoxCash.Name = "textBoxCash";
            this.textBoxCash.ReadOnly = true;
            this.textBoxCash.Size = new System.Drawing.Size(139, 21);
            this.textBoxCash.TabIndex = 3;
            this.textBoxCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkedListBoxServices
            // 
            this.checkedListBoxServices.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBoxServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxServices.FormattingEnabled = true;
            this.checkedListBoxServices.Location = new System.Drawing.Point(12, 11);
            this.checkedListBoxServices.Name = "checkedListBoxServices";
            this.checkedListBoxServices.Size = new System.Drawing.Size(493, 240);
            this.checkedListBoxServices.TabIndex = 4;
            this.checkedListBoxServices.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxServices_SelectedIndexChanged);
            // 
            // buttonDeleteServices
            // 
            this.buttonDeleteServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteServices.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteServices.Location = new System.Drawing.Point(66, 262);
            this.buttonDeleteServices.Name = "buttonDeleteServices";
            this.buttonDeleteServices.Size = new System.Drawing.Size(139, 30);
            this.buttonDeleteServices.TabIndex = 5;
            this.buttonDeleteServices.Text = "Удалить";
            this.buttonDeleteServices.UseVisualStyleBackColor = true;
            this.buttonDeleteServices.Click += new System.EventHandler(this.buttonDeleteServices_Click);
            // 
            // buttonPayServices
            // 
            this.buttonPayServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPayServices.ForeColor = System.Drawing.Color.White;
            this.buttonPayServices.Location = new System.Drawing.Point(321, 262);
            this.buttonPayServices.Name = "buttonPayServices";
            this.buttonPayServices.Size = new System.Drawing.Size(139, 30);
            this.buttonPayServices.TabIndex = 6;
            this.buttonPayServices.Text = "Оплатить";
            this.buttonPayServices.UseVisualStyleBackColor = true;
            this.buttonPayServices.Click += new System.EventHandler(this.buttonPayServices_Click);
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(531, 271);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.Size = new System.Drawing.Size(100, 21);
            this.textBoxTotalPrice.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(528, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Итоговая сумма";
            // 
            // buttonHistory
            // 
            this.buttonHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHistory.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHistory.ForeColor = System.Drawing.Color.White;
            this.buttonHistory.Location = new System.Drawing.Point(12, 255);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(37, 37);
            this.buttonHistory.TabIndex = 9;
            this.buttonHistory.Text = "📝";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(658, 301);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.buttonPayServices);
            this.Controls.Add(this.buttonDeleteServices);
            this.Controls.Add(this.checkedListBoxServices);
            this.Controls.Add(this.textBoxCash);
            this.Controls.Add(this.buttonAddCash);
            this.Controls.Add(this.buttonBookARoom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WelcomeForm_FormClosed);
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBookARoom;
        private System.Windows.Forms.Button buttonAddCash;
        public System.Windows.Forms.TextBox textBoxCash;
        private System.Windows.Forms.CheckedListBox checkedListBoxServices;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonDeleteServices;
        private System.Windows.Forms.Button buttonPayServices;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHistory;
    }
}