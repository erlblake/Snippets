namespace snippets
{
    partial class BookingInformation
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DropDownListofStylists = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationList = new System.Windows.Forms.ComboBox();
            this.Bookingbutton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(40, 83);
            this.dateTimePicker1.MinDate = new System.DateTime(2018, 4, 24, 20, 17, 16, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(289, 31);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2018, 4, 24, 20, 17, 16, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // DropDownListofStylists
            // 
            this.DropDownListofStylists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownListofStylists.FormattingEnabled = true;
            this.DropDownListofStylists.Location = new System.Drawing.Point(473, 85);
            this.DropDownListofStylists.Name = "DropDownListofStylists";
            this.DropDownListofStylists.Size = new System.Drawing.Size(199, 33);
            this.DropDownListofStylists.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(40, 179);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(632, 454);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(35, 693);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(93, 25);
            this.DurationLabel.TabIndex = 3;
            this.DurationLabel.Text = "Duration";
            // 
            // DurationList
            // 
            this.DurationList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DurationList.FormattingEnabled = true;
            this.DurationList.Location = new System.Drawing.Point(157, 690);
            this.DurationList.Name = "DurationList";
            this.DurationList.Size = new System.Drawing.Size(121, 33);
            this.DurationList.TabIndex = 4;
            // 
            // Bookingbutton
            // 
            this.Bookingbutton.Location = new System.Drawing.Point(304, 690);
            this.Bookingbutton.Name = "Bookingbutton";
            this.Bookingbutton.Size = new System.Drawing.Size(205, 42);
            this.Bookingbutton.TabIndex = 5;
            this.Bookingbutton.Text = "Book Appointment";
            this.Bookingbutton.UseVisualStyleBackColor = true;
            this.Bookingbutton.Click += new System.EventHandler(this.Bookingbutton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(539, 690);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(133, 42);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BookingInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 795);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Bookingbutton);
            this.Controls.Add(this.DurationList);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.DropDownListofStylists);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "BookingInformation";
            this.Text = "BookingInformation";
            this.Load += new System.EventHandler(this.BookingInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox DropDownListofStylists;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.ComboBox DurationList;
        private System.Windows.Forms.Button Bookingbutton;
        private System.Windows.Forms.Button CancelButton;
    }
}