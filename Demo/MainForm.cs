using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MonoLib.Async;

namespace Demo
{
	public partial class MainForm : Form
	{
		public MainForm ()
		{
			InitializeComponent ();
		}

		void ReportError (string error)
		{
			MessageBox.Show (this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private async void btnDownload_Click (object sender, EventArgs args)
		{
			Uri uri;
			try
			{
				uri = new Uri (txtAddress.Text);
			}
			catch (Exception e)
			{
				ReportError (e.ToString ());
				return;
			}

			btnDownload.Enabled = false;
			var wc = new WebClient ();

			try
			{
				txtResult.Text = await wc.DownloadStringAsync2 (uri);
			}
			catch (Exception e)
			{
				ReportError (e.ToString ());
				throw;
			}
			btnDownload.Enabled = true;
			
		}
	}
}
