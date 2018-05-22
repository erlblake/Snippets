namespace snippets
{
    partial class StylistSelectionForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.StylistSearch = new System.Windows.Forms.TextBox();
            this.ListofStylists = new System.Windows.Forms.ListBox();
            this.EditStylistButton = new System.Windows.Forms.Button();
            this.NewStylist = new System.Windows.Forms.Button();
            this.AddChairButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(50, 85);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(108, 40);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // StylistSearch
            // 
            this.StylistSearch.Location = new System.Drawing.Point(179, 90);
            this.StylistSearch.Name = "StylistSearch";
            this.StylistSearch.Size = new System.Drawing.Size(768, 31);
            this.StylistSearch.TabIndex = 1;
            // 
            // ListofStylists
            // 
            this.ListofStylists.FormattingEnabled = true;
            this.ListofStylists.ItemHeight = 25;
            this.ListofStylists.Location = new System.Drawing.Point(50, 174);
            this.ListofStylists.Name = "ListofStylists";
            this.ListofStylists.Size = new System.Drawing.Size(897, 604);
            this.ListofStylists.TabIndex = 2;
            this.ListofStylists.SelectedIndexChanged += new System.EventHandler(this.ListofStylists_SelectedIndexChanged);
            // 
            // EditStylistButton
            // 
            this.EditStylistButton.Location = new System.Drawing.Point(50, 818);
            this.EditStylistButton.Name = "EditStylistButton";
            this.EditStylistButton.Size = new System.Drawing.Size(248, 38);
            this.EditStylistButton.TabIndex = 3;
            this.EditStylistButton.Text = "Edit Selected Stylist";
            this.EditStylistButton.UseVisualStyleBackColor = true;
            this.EditStylistButton.Click += new System.EventHandler(this.EditStylistButton_Click);
            // 
            // NewStylist
            // 
            this.NewStylist.Location = new System.Drawing.Point(317, 818);
            this.NewStylist.Name = "NewStylist";
            this.NewStylist.Size = new System.Drawing.Size(202, 38);
            this.NewStylist.TabIndex = 4;
            this.NewStylist.Text = "Add New Stylist";
            this.NewStylist.UseVisualStyleBackColor = true;
            this.NewStylist.Click += new System.EventHandler(this.NewStylist_Click);
            // 
            // AddChairButton
            // 
            this.AddChairButton.Location = new System.Drawing.Point(804, 818);
            this.AddChairButton.Name = "AddChairButton";
            this.AddChairButton.Size = new System.Drawing.Size(143, 38);
            this.AddChairButton.TabIndex = 5;
            this.AddChairButton.Text = "Add Chair";
            this.AddChairButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(525, 820);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(261, 31);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // StylistSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 940);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.AddChairButton);
            this.Controls.Add(this.NewStylist);
            this.Controls.Add(this.EditStylistButton);
            this.Controls.Add(this.ListofStylists);
            this.Controls.Add(this.StylistSearch);
            this.Controls.Add(this.SearchButton);
            this.Name = "StylistSelectionForm";
            this.Text = "StylistSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox StylistSearch;
        private System.Windows.Forms.ListBox ListofStylists;
        private System.Windows.Forms.Button EditStylistButton;
        private System.Windows.Forms.Button NewStylist;
        private System.Windows.Forms.Button AddChairButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}