namespace snippets
{
    partial class CustomersSelectionFormcs
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
            this.BookAppointmentButton = new System.Windows.Forms.Button();
            this.NewCustomer = new System.Windows.Forms.Button();
            this.EditCustomerButton = new System.Windows.Forms.Button();
            this.CustomerSelectionListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookAppointmentButton
            // 
            this.BookAppointmentButton.Location = new System.Drawing.Point(750, 831);
            this.BookAppointmentButton.Name = "BookAppointmentButton";
            this.BookAppointmentButton.Size = new System.Drawing.Size(225, 38);
            this.BookAppointmentButton.TabIndex = 12;
            this.BookAppointmentButton.Text = "Book Appointment";
            this.BookAppointmentButton.UseVisualStyleBackColor = true;
            this.BookAppointmentButton.Click += new System.EventHandler(this.BookAppointmentButton_Click);
            // 
            // NewCustomer
            // 
            this.NewCustomer.Location = new System.Drawing.Point(428, 831);
            this.NewCustomer.Name = "NewCustomer";
            this.NewCustomer.Size = new System.Drawing.Size(269, 38);
            this.NewCustomer.TabIndex = 11;
            this.NewCustomer.Text = "Add New Customer";
            this.NewCustomer.UseVisualStyleBackColor = true;
            this.NewCustomer.Click += new System.EventHandler(this.NewCustomer_Click);
            // 
            // EditCustomerButton
            // 
            this.EditCustomerButton.Location = new System.Drawing.Point(78, 831);
            this.EditCustomerButton.Name = "EditCustomerButton";
            this.EditCustomerButton.Size = new System.Drawing.Size(248, 38);
            this.EditCustomerButton.TabIndex = 10;
            this.EditCustomerButton.Text = "Edit Selected Customer";
            this.EditCustomerButton.UseVisualStyleBackColor = true;
            this.EditCustomerButton.Click += new System.EventHandler(this.EditCustomerButton_Click);
            // 
            // CustomerSelectionListBox
            // 
            this.CustomerSelectionListBox.FormattingEnabled = true;
            this.CustomerSelectionListBox.ItemHeight = 25;
            this.CustomerSelectionListBox.Location = new System.Drawing.Point(78, 187);
            this.CustomerSelectionListBox.Name = "CustomerSelectionListBox";
            this.CustomerSelectionListBox.Size = new System.Drawing.Size(897, 604);
            this.CustomerSelectionListBox.TabIndex = 9;
            this.CustomerSelectionListBox.SelectedIndexChanged += new System.EventHandler(this.CustomerSelectionListBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(207, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(768, 31);
            this.textBox1.TabIndex = 8;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(78, 98);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(108, 40);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // CustomersSelectionFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 966);
            this.Controls.Add(this.BookAppointmentButton);
            this.Controls.Add(this.NewCustomer);
            this.Controls.Add(this.EditCustomerButton);
            this.Controls.Add(this.CustomerSelectionListBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SearchButton);
            this.Name = "CustomersSelectionFormcs";
            this.Text = "CustomersSelectionFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BookAppointmentButton;
        private System.Windows.Forms.Button NewCustomer;
        private System.Windows.Forms.Button EditCustomerButton;
        private System.Windows.Forms.ListBox CustomerSelectionListBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SearchButton;
    }
}