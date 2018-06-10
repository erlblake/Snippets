namespace snippets
{
    partial class Menu
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
            this.CustomersButton = new System.Windows.Forms.Button();
            this.StylistsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomersButton
            // 
            this.CustomersButton.Location = new System.Drawing.Point(89, 73);
            this.CustomersButton.Name = "CustomersButton";
            this.CustomersButton.Size = new System.Drawing.Size(195, 53);
            this.CustomersButton.TabIndex = 0;
            this.CustomersButton.Text = "Customers";
            this.CustomersButton.UseVisualStyleBackColor = true;
            this.CustomersButton.Click += new System.EventHandler(this.CustomersButton_Click);
            // 
            // StylistsButton
            // 
            this.StylistsButton.Location = new System.Drawing.Point(89, 143);
            this.StylistsButton.Name = "StylistsButton";
            this.StylistsButton.Size = new System.Drawing.Size(195, 53);
            this.StylistsButton.TabIndex = 1;
            this.StylistsButton.Text = "Stylists";
            this.StylistsButton.UseVisualStyleBackColor = true;
            this.StylistsButton.Click += new System.EventHandler(this.StylistsButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 285);
            this.Controls.Add(this.StylistsButton);
            this.Controls.Add(this.CustomersButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CustomersButton;
        private System.Windows.Forms.Button StylistsButton;
    }
}