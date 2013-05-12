namespace Demo
{
	partial class MainForm
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
			if (disposing && (components != null))
			{
				components.Dispose ();
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDownload = new System.Windows.Forms.Button();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.txtAddress);
			this.panel1.Controls.Add(this.btnDownload);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(636, 22);
			this.panel1.TabIndex = 0;
			// 
			// btnDownload
			// 
			this.btnDownload.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnDownload.Location = new System.Drawing.Point(561, 0);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(75, 22);
			this.btnDownload.TabIndex = 0;
			this.btnDownload.Text = "Download";
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// txtAddress
			// 
			this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAddress.Location = new System.Drawing.Point(0, 0);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(561, 20);
			this.txtAddress.TabIndex = 1;
			this.txtAddress.Text = "https://gist.github.com/kekekeks/5563048/raw/6769dd60bdf536a83c9353272157893043e9" +
    "f7d0/test";
			// 
			// txtResult
			// 
			this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResult.Location = new System.Drawing.Point(0, 22);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResult.Size = new System.Drawing.Size(636, 299);
			this.txtResult.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(636, 321);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Demo";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.TextBox txtResult;
	}
}

