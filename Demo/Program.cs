using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Demo
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ()
		{
			System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);
			Application.Run (new MainForm ());
		}
	}
}
