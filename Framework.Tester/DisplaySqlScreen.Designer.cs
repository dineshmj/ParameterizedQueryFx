namespace ParameterizedQuery.Framework.Tester
{
	partial class DisplaySqlScreen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (this.components != null))
			{
				this.components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.sqlTextArea = new System.Windows.Forms.TextBox();
			this.rebuildSqlButton = new System.Windows.Forms.Button();
			this.quitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sqlTextArea
			// 
			this.sqlTextArea.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sqlTextArea.Location = new System.Drawing.Point(3, 4);
			this.sqlTextArea.Multiline = true;
			this.sqlTextArea.Name = "sqlTextArea";
			this.sqlTextArea.ReadOnly = true;
			this.sqlTextArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.sqlTextArea.Size = new System.Drawing.Size(1180, 530);
			this.sqlTextArea.TabIndex = 0;
			// 
			// rebuildSqlButton
			// 
			this.rebuildSqlButton.Location = new System.Drawing.Point(1190, 511);
			this.rebuildSqlButton.Name = "rebuildSqlButton";
			this.rebuildSqlButton.Size = new System.Drawing.Size(93, 23);
			this.rebuildSqlButton.TabIndex = 1;
			this.rebuildSqlButton.Text = "Rebuild SQL";
			this.rebuildSqlButton.UseVisualStyleBackColor = true;
			this.rebuildSqlButton.Click += new System.EventHandler(this.rebuildSqlButton_Click);
			// 
			// quitButton
			// 
			this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.quitButton.Location = new System.Drawing.Point(1190, 482);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(93, 23);
			this.quitButton.TabIndex = 2;
			this.quitButton.Text = "Close";
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
			// 
			// DisplaySqlScreen
			// 
			this.AcceptButton = this.rebuildSqlButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.quitButton;
			this.ClientSize = new System.Drawing.Size(1295, 536);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.rebuildSqlButton);
			this.Controls.Add(this.sqlTextArea);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "DisplaySqlScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Display SQL Text";
			this.Load += new System.EventHandler(this.DisplaySqlScreen_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox sqlTextArea;
		private System.Windows.Forms.Button rebuildSqlButton;
		private System.Windows.Forms.Button quitButton;
	}
}