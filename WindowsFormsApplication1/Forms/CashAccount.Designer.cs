namespace WindowsFormsApplication1.Forms
{
    partial class CashAccount
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
            this.textBoxAddCash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonEuro = new System.Windows.Forms.RadioButton();
            this.radioButtonDollar = new System.Windows.Forms.RadioButton();
            this.radioButtonRuble = new System.Windows.Forms.RadioButton();
            this.buttonAddCash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddCash
            // 
            this.textBoxAddCash.Location = new System.Drawing.Point(41, 42);
            this.textBoxAddCash.MaxLength = 5;
            this.textBoxAddCash.Name = "textBoxAddCash";
            this.textBoxAddCash.Size = new System.Drawing.Size(140, 21);
            this.textBoxAddCash.TabIndex = 0;
            this.textBoxAddCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddCash_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сумма пополнения";
            // 
            // radioButtonEuro
            // 
            this.radioButtonEuro.AutoSize = true;
            this.radioButtonEuro.BackColor = System.Drawing.Color.DarkSlateGray;
            this.radioButtonEuro.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEuro.ForeColor = System.Drawing.Color.White;
            this.radioButtonEuro.Location = new System.Drawing.Point(41, 65);
            this.radioButtonEuro.Name = "radioButtonEuro";
            this.radioButtonEuro.Size = new System.Drawing.Size(33, 20);
            this.radioButtonEuro.TabIndex = 2;
            this.radioButtonEuro.TabStop = true;
            this.radioButtonEuro.Text = "€";
            this.radioButtonEuro.UseVisualStyleBackColor = false;
            // 
            // radioButtonDollar
            // 
            this.radioButtonDollar.AutoSize = true;
            this.radioButtonDollar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.radioButtonDollar.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDollar.ForeColor = System.Drawing.Color.White;
            this.radioButtonDollar.Location = new System.Drawing.Point(97, 65);
            this.radioButtonDollar.Name = "radioButtonDollar";
            this.radioButtonDollar.Size = new System.Drawing.Size(32, 20);
            this.radioButtonDollar.TabIndex = 3;
            this.radioButtonDollar.TabStop = true;
            this.radioButtonDollar.Text = "$";
            this.radioButtonDollar.UseVisualStyleBackColor = false;
            // 
            // radioButtonRuble
            // 
            this.radioButtonRuble.AutoSize = true;
            this.radioButtonRuble.BackColor = System.Drawing.Color.DarkSlateGray;
            this.radioButtonRuble.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRuble.ForeColor = System.Drawing.Color.White;
            this.radioButtonRuble.Location = new System.Drawing.Point(148, 65);
            this.radioButtonRuble.Name = "radioButtonRuble";
            this.radioButtonRuble.Size = new System.Drawing.Size(41, 20);
            this.radioButtonRuble.TabIndex = 4;
            this.radioButtonRuble.TabStop = true;
            this.radioButtonRuble.Text = "☭";
            this.radioButtonRuble.UseVisualStyleBackColor = false;
            // 
            // buttonAddCash
            // 
            this.buttonAddCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCash.ForeColor = System.Drawing.Color.White;
            this.buttonAddCash.Location = new System.Drawing.Point(67, 88);
            this.buttonAddCash.Name = "buttonAddCash";
            this.buttonAddCash.Size = new System.Drawing.Size(75, 28);
            this.buttonAddCash.TabIndex = 5;
            this.buttonAddCash.Text = "Пополнить";
            this.buttonAddCash.UseVisualStyleBackColor = true;
            this.buttonAddCash.Click += new System.EventHandler(this.buttonAddCash_Click);
            // 
            // CashAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(222, 128);
            this.Controls.Add(this.buttonAddCash);
            this.Controls.Add(this.radioButtonRuble);
            this.Controls.Add(this.radioButtonDollar);
            this.Controls.Add(this.radioButtonEuro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddCash);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CashAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пополнить счет";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CashAccount_FormClosed);
            this.Load += new System.EventHandler(this.CashAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddCash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonEuro;
        private System.Windows.Forms.RadioButton radioButtonDollar;
        private System.Windows.Forms.RadioButton radioButtonRuble;
        private System.Windows.Forms.Button buttonAddCash;
    }
}