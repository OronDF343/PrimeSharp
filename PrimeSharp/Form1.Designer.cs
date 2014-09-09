namespace PrimeSharp
{
    partial class Form1
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
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.logLabel = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.memUseLabel = new System.Windows.Forms.Label();
            this.sysInfoLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Length:";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(91, 13);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(224, 20);
            this.txtLength.TabIndex = 1;
            this.txtLength.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save:";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(91, 42);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(143, 20);
            this.txtFilename.TabIndex = 3;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(240, 40);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 4;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(14, 103);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(42, 13);
            this.logLabel.TabIndex = 5;
            this.logLabel.Text = "Output:";
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(240, 69);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 6;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // memUseLabel
            // 
            this.memUseLabel.AutoSize = true;
            this.memUseLabel.Location = new System.Drawing.Point(13, 74);
            this.memUseLabel.Name = "memUseLabel";
            this.memUseLabel.Size = new System.Drawing.Size(147, 13);
            this.memUseLabel.TabIndex = 7;
            this.memUseLabel.Text = "Est. memory usage / file size: ";
            // 
            // sysInfoLabel
            // 
            this.sysInfoLabel.AutoSize = true;
            this.sysInfoLabel.Location = new System.Drawing.Point(14, 280);
            this.sysInfoLabel.Name = "sysInfoLabel";
            this.sysInfoLabel.Size = new System.Drawing.Size(59, 13);
            this.sysInfoLabel.TabIndex = 8;
            this.sysInfoLabel.Text = "SystemInfo";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(240, 275);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 362);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.sysInfoLabel);
            this.Controls.Add(this.memUseLabel);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Prime# Alpha v1.1 by OronDF343";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label memUseLabel;
        private System.Windows.Forms.Label sysInfoLabel;
        private System.Windows.Forms.Button refreshButton;
    }
}

