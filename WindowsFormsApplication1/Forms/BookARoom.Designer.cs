
namespace WindowsFormsApplication1.Classes
{
    partial class BookARoom
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
            this.dateOfArriving = new System.Windows.Forms.DateTimePicker();
            this.dateOfLeaving = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRooms = new System.Windows.Forms.ComboBox();
            this.buttonBook = new System.Windows.Forms.Button();
            this.textBoxPriceOfRooms = new System.Windows.Forms.TextBox();
            this.comboBoxServices = new System.Windows.Forms.ComboBox();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxPriceOfServices = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateOfArriving
            // 
            this.dateOfArriving.Location = new System.Drawing.Point(419, 129);
            this.dateOfArriving.Name = "dateOfArriving";
            this.dateOfArriving.Size = new System.Drawing.Size(244, 20);
            this.dateOfArriving.TabIndex = 15;
            // 
            // dateOfLeaving
            // 
            this.dateOfLeaving.Location = new System.Drawing.Point(419, 195);
            this.dateOfLeaving.Name = "dateOfLeaving";
            this.dateOfLeaving.Size = new System.Drawing.Size(244, 20);
            this.dateOfLeaving.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(416, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Дата заезда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(416, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Дата выезда";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxRooms
            // 
            this.comboBoxRooms.FormattingEnabled = true;
            this.comboBoxRooms.Location = new System.Drawing.Point(44, 28);
            this.comboBoxRooms.Name = "comboBoxRooms";
            this.comboBoxRooms.Size = new System.Drawing.Size(244, 21);
            this.comboBoxRooms.TabIndex = 20;
            this.comboBoxRooms.SelectedIndexChanged += new System.EventHandler(this.comboBoxRooms_SelectedIndexChanged);
            // 
            // buttonBook
            // 
            this.buttonBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBook.ForeColor = System.Drawing.Color.White;
            this.buttonBook.Location = new System.Drawing.Point(263, 251);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(161, 26);
            this.buttonBook.TabIndex = 21;
            this.buttonBook.Text = "Забронировать";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // textBoxPriceOfRooms
            // 
            this.textBoxPriceOfRooms.Location = new System.Drawing.Point(417, 29);
            this.textBoxPriceOfRooms.Name = "textBoxPriceOfRooms";
            this.textBoxPriceOfRooms.Size = new System.Drawing.Size(235, 20);
            this.textBoxPriceOfRooms.TabIndex = 22;
            // 
            // comboBoxServices
            // 
            this.comboBoxServices.FormattingEnabled = true;
            this.comboBoxServices.Location = new System.Drawing.Point(44, 78);
            this.comboBoxServices.Name = "comboBoxServices";
            this.comboBoxServices.Size = new System.Drawing.Size(244, 21);
            this.comboBoxServices.TabIndex = 23;
            this.comboBoxServices.SelectedIndexChanged += new System.EventHandler(this.comboBoxServices_SelectedIndexChanged);
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(44, 221);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.Size = new System.Drawing.Size(147, 20);
            this.textBoxTotalPrice.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(41, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Общая стоимость";
            // 
            // richTextBoxPriceOfServices
            // 
            this.richTextBoxPriceOfServices.Location = new System.Drawing.Point(44, 105);
            this.richTextBoxPriceOfServices.Name = "richTextBoxPriceOfServices";
            this.richTextBoxPriceOfServices.Size = new System.Drawing.Size(244, 78);
            this.richTextBoxPriceOfServices.TabIndex = 27;
            this.richTextBoxPriceOfServices.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(53, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Выбор комнаты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(52, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Выбор пакета услуг";
            // 
            // BookARoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(709, 322);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxPriceOfServices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.comboBoxServices);
            this.Controls.Add(this.textBoxPriceOfRooms);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.comboBoxRooms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateOfLeaving);
            this.Controls.Add(this.dateOfArriving);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "BookARoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookARoom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookARoom_FormClosed);
            this.Load += new System.EventHandler(this.BookARoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateOfArriving;
        private System.Windows.Forms.DateTimePicker dateOfLeaving;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRooms;
        private System.Windows.Forms.Button buttonBook;
        private System.Windows.Forms.TextBox textBoxPriceOfRooms;
        private System.Windows.Forms.ComboBox comboBoxServices;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxPriceOfServices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}