namespace Terminal_Publisher
{
    partial class Form_Publisher
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
            this.button_green = new System.Windows.Forms.Button();
            this.button_red = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_green
            // 
            this.button_green.BackColor = System.Drawing.Color.Lime;
            this.button_green.Location = new System.Drawing.Point(107, 102);
            this.button_green.Name = "button_green";
            this.button_green.Size = new System.Drawing.Size(270, 88);
            this.button_green.TabIndex = 0;
            this.button_green.Text = "\"ON\" - Geçiş Serbest";
            this.button_green.UseVisualStyleBackColor = false;
            this.button_green.Click += new System.EventHandler(this.button_green_Click);
            // 
            // button_red
            // 
            this.button_red.BackColor = System.Drawing.Color.Red;
            this.button_red.Location = new System.Drawing.Point(412, 102);
            this.button_red.Name = "button_red";
            this.button_red.Size = new System.Drawing.Size(270, 88);
            this.button_red.TabIndex = 1;
            this.button_red.Text = "\"OFF\" - Geçiş Kapalı";
            this.button_red.UseVisualStyleBackColor = false;
            this.button_red.Click += new System.EventHandler(this.button_red_Click);
            // 
            // Form_Publisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 291);
            this.Controls.Add(this.button_red);
            this.Controls.Add(this.button_green);
            this.Name = "Form_Publisher";
            this.Text = "Publisher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Publisher_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_green;
        private System.Windows.Forms.Button button_red;
    }
}

