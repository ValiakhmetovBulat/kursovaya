
namespace WindowsFormsApplication1.Forms
{
    partial class OrderHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxPaidOrders = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDeletedOrders = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClearPaidOrders = new System.Windows.Forms.Button();
            this.buttonClearDeletedOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(168, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "История заказов";
            // 
            // richTextBoxPaidOrders
            // 
            this.richTextBoxPaidOrders.Location = new System.Drawing.Point(12, 72);
            this.richTextBoxPaidOrders.Name = "richTextBoxPaidOrders";
            this.richTextBoxPaidOrders.Size = new System.Drawing.Size(247, 165);
            this.richTextBoxPaidOrders.TabIndex = 1;
            this.richTextBoxPaidOrders.Text = "";
            // 
            // richTextBoxDeletedOrders
            // 
            this.richTextBoxDeletedOrders.Location = new System.Drawing.Point(270, 72);
            this.richTextBoxDeletedOrders.Name = "richTextBoxDeletedOrders";
            this.richTextBoxDeletedOrders.Size = new System.Drawing.Size(247, 165);
            this.richTextBoxDeletedOrders.TabIndex = 2;
            this.richTextBoxDeletedOrders.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Оплаченные";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(267, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Удаленные";
            // 
            // buttonClearPaidOrders
            // 
            this.buttonClearPaidOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearPaidOrders.Location = new System.Drawing.Point(95, 243);
            this.buttonClearPaidOrders.Name = "buttonClearPaidOrders";
            this.buttonClearPaidOrders.Size = new System.Drawing.Size(75, 23);
            this.buttonClearPaidOrders.TabIndex = 5;
            this.buttonClearPaidOrders.Text = "Очистить";
            this.buttonClearPaidOrders.UseVisualStyleBackColor = true;
            this.buttonClearPaidOrders.Click += new System.EventHandler(this.buttonClearPaidOrders_Click);
            // 
            // buttonClearDeletedOrders
            // 
            this.buttonClearDeletedOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearDeletedOrders.Location = new System.Drawing.Point(369, 243);
            this.buttonClearDeletedOrders.Name = "buttonClearDeletedOrders";
            this.buttonClearDeletedOrders.Size = new System.Drawing.Size(75, 23);
            this.buttonClearDeletedOrders.TabIndex = 6;
            this.buttonClearDeletedOrders.Text = "Очистить";
            this.buttonClearDeletedOrders.UseVisualStyleBackColor = true;
            this.buttonClearDeletedOrders.Click += new System.EventHandler(this.buttonClearDeletedOrders_Click);
            // 
            // OrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(529, 271);
            this.Controls.Add(this.buttonClearDeletedOrders);
            this.Controls.Add(this.buttonClearPaidOrders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxDeletedOrders);
            this.Controls.Add(this.richTextBoxPaidOrders);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OrderHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderHistory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderHistory_FormClosed);
            this.Load += new System.EventHandler(this.OrderHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxPaidOrders;
        private System.Windows.Forms.RichTextBox richTextBoxDeletedOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClearPaidOrders;
        private System.Windows.Forms.Button buttonClearDeletedOrders;
    }
}